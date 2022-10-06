<?php
require_once "json.php";
class Pizza{
    public $sabor;
    public $precio;
    public $tipo;
    public $cantidad;
    public $id;
    private $nombreFoto;

    public function __construct($sabor_pizza, $precio_pizza, $tipo_pizza, $cantidad_pizza, $id, $nombreFoto = ""){
        if (is_string($sabor_pizza)){
            $this->sabor = $sabor_pizza;
        }
        if (is_float($precio_pizza)){
            $this->precio = $precio_pizza;
        }
        if (is_string($tipo_pizza) && ($tipo_pizza == "molde" || $tipo_pizza == "piedra")){
            $this->tipo = $tipo_pizza;
        } else $this->tipo = "molde";
        if(is_int($cantidad_pizza)){
            $this->cantidad = $cantidad_pizza;
        }
        $this->id = $id;
        $this->nombreFoto = $nombreFoto;
    }

    public function getId(){
        return $this->id;
    }

    public function setPrecio($value){
        if (is_float($value)){
            $this->precio = $value;
        }
    }

    public function SetStock($nuevoStock){
        if (is_int($nuevoStock)){
            $this->cantidad = $nuevoStock;
        }
    }
    
    public function SumarStock($nuevoStock){
        if (is_int($nuevoStock)){
            $this->cantidad += $nuevoStock;
        }
    }

    public function SetNombreFoto(){
        $this->nombreFoto = $this->tipo . "-" . $this->sabor;
    }
    
    public static function LeerPizzasJson($arrayDePizzas = array()){
        $datosJson = JSON::LecturaJson("pizza.json");
        if (!empty($datosJson)){
            for ($i = 0; $i < count($datosJson); $i++){
                $pizza = new Pizza(
                $datosJson[$i]["sabor"],
                floatval($datosJson[$i]["precio"]),
                $datosJson[$i]["tipo"],
                intval($datosJson[$i]["cantidad"]),
                intval($datosJson[$i]["id"])
                );
                array_push($arrayDePizzas, $pizza);
            }
        }
        return $arrayDePizzas;
    }

    public static function GuardarPizza($pizza){
        if (is_a($pizza, "Pizza")){
            $arrayDePizzas = self::LeerPizzasJson();
            if(!$pizza->VerificarPizza($pizza, $arrayDePizzas)){
                $pizza->GuardarImagenPizza();
                array_push($arrayDePizzas, $pizza);                
            }
            return JSON::EscrituraJson("pizza.json", $arrayDePizzas);
        }
        return "El objeto enviado no es una Pizza.";
    }

    public function VerificarPizza($pizzaAComparar, $arrayDePizzas){
        if (count($arrayDePizzas) > 0 && is_a($pizzaAComparar, "Pizza")){
            foreach($arrayDePizzas as $pizzaArray){
                if ($pizzaArray->Equals($pizzaAComparar)){
                    $pizzaArray->setPrecio($pizzaAComparar->precio);
                    $pizzaArray->SumarStock($pizzaAComparar->cantidad);
                    return true;
                }
            }
        }
        return false;
    }

    public function Equals($pizzaAComparar){
        return is_a($pizzaAComparar, "Pizza") ? 
        $this->sabor == $pizzaAComparar->sabor && $this->tipo == $pizzaAComparar->tipo : false;
    }
    
    public static function UltimoIdRegistrado(){
        $arrayDePizzas = self::LeerPizzasJSON();
        $maximo = 0;
        if (count($arrayDePizzas) > 0){
            foreach($arrayDePizzas as $pizzaArray){
                if ($pizzaArray->getId() > $maximo){
                    $maximo = $pizzaArray->getId();
                }
            }
        }
        return $maximo;
    }

    public static function ConsultarExistencia($pizzaParam){
        $arrayDePizzas = self::LeerPizzasJSON();
        if (count($arrayDePizzas) > 0 && is_a($pizzaParam, "Pizza")){
            $existeSabor = false;
            $existeTipo = false;
            foreach ($arrayDePizzas as $pizza){
                if ($pizza->sabor == $pizzaParam->sabor){
                    $existeSabor = true;
                    break;
                }
            }
            foreach ($arrayDePizzas as $pizza){
                if ($pizza->sabor == $pizzaParam->sabor && $pizza->tipo == $pizzaParam->tipo){
                    $existeTipo = true;
                    break;
                }
            }
            if ($existeSabor && $existeTipo){
                return 1;
            }
            else if ($existeSabor && !$existeTipo){
                return 2;
            } else if (!$existeSabor){
                return 3;
            }
            return $mensaje;
        } else return -1;
    }

    public static function ObtenerPizza($pizzaParam){
        $arrayDePizzas = self::LeerPizzasJson();
        if (count($arrayDePizzas) > 0){
            foreach($arrayDePizzas as $pizzaArray){
                if ($pizzaArray->Equals($pizzaParam)){
                    return $pizzaArray;
                }
            }
        }
        return null;
    }

    public function GuardarImagenPizza(){
        $dir = 'ImagenesDePizzas/';
        if (!file_exists($dir)){
            mkdir($dir, 0777, true);
        }
        $this->SetNombreFoto();
        $extension = pathinfo($_FILES["image"]["name"], PATHINFO_EXTENSION);
        $destino = $dir . $this->nombreFoto . "." . $extension;
        $tipoArchivo = pathinfo($destino, PATHINFO_EXTENSION);
        if ($tipoArchivo != 'jpg' && $tipoArchivo != 'png' && $tipoArchivo != 'bmp'){
            echo 'Sólo se aceptan imagenes JPG, PNG y BMP!';
            return false;
        } else{
            return move_uploaded_file($_FILES["image"]["tmp_name"], $destino);
        }
    }
}
?>