<?php
require_once "json.php";
class Hamburguesa{
    public $nombre;
    public $precio;
    public $tipo;
    public $cantidad;
    public $id;
    private $nombreFoto;

    public function __construct($nombre, $precio, $tipo, $cantidad, $id = 0, $nombreFoto = ""){
        if (is_string($nombre)){
            $this->nombre = $nombre;
        }
        if (is_string($tipo) && ($tipo == "simple" || $tipo == "doble")){
            $this->tipo = $tipo;
        } else $this->tipo = "simple";
        if (is_float($precio)){
            $this->precio = $precio;
        }
        if (is_int($cantidad)){
            $this->cantidad = $cantidad;
        }
        $this->nombreFoto = $nombreFoto;
        $this->id = $id;
    }

    public function SetNombreFoto(){
        $this->nombreFoto = $this->GetTipo() . "-" . $this->GetNombre();
    }

    public function GetNombreFoto(){
        return $this->nombreFoto;
    }

    public function GetId(){
        return $this->id;
    }

    public function GetPrecio(){
        return $this->precio;
    }

    public function SetPrecio($value){
        if (!empty($value) && is_float($value)){
            $this->precio = $value;
        }
    }

    public function GetStock(){
        return $this->cantidad;
    }

    public function SetStock($value){
        if (!empty($value) && is_int($value)){
            $this->cantidad = $value;
        }
    }

    public function SumarStock($value){
        if (!empty($value) && is_int($value)){
            $this->cantidad += $value;
        }
    }

    public function GetNombre(){
        return $this->nombre;
    }

    public function GetTipo(){
        return $this->tipo;
    }

    public static function GuardarHamburguesa($hamburguesa){
        $arrayDeHamburguesas = self::LeerHamburguesasJSON();
        if (!self::VerificarHamburguesa($hamburguesa, $arrayDeHamburguesas)){
            $hamburguesa->GuardarImagenHamburguesa();
            array_push($arrayDeHamburguesas, $hamburguesa);
        }
        return JSON::EscrituraJson("hamburguesas.json", $arrayDeHamburguesas);
    }

    public static function LeerHamburguesasJSON($arrayDeHamburguesas = array()){
        $datosJson = JSON::LecturaJson("hamburguesas.json");
        if (!empty($datosJson)){
            for ($i = 0; $i < count($datosJson); $i++){
                $hamburguesa = new Hamburguesa(
                $datosJson[$i]["nombre"],
                floatval($datosJson[$i]["precio"]),
                $datosJson[$i]["tipo"],
                intval($datosJson[$i]["cantidad"]),
                intval($datosJson[$i]["id"])
                );
                array_push($arrayDeHamburguesas, $hamburguesa);
            }
        }
        return $arrayDeHamburguesas;
    }

    public function Equals($hamburguesaAComparar){
        return is_a($hamburguesaAComparar, "Hamburguesa") ? 
        $this->GetNombre() == $hamburguesaAComparar->GetNombre() && $this->GetTipo() == $hamburguesaAComparar->GetTipo()
        : false;
    }

    public static function VerificarHamburguesa($hamburguesaAComparar, $arrayDeHamburguesas){
        if (count($arrayDeHamburguesas) > 0 && is_a($hamburguesaAComparar, "Hamburguesa")){
            foreach($arrayDeHamburguesas as $hamburguesaAux){
                if ($hamburguesaAux->Equals($hamburguesaAComparar)){
                    $hamburguesaAux->SetPrecio($hamburguesaAComparar->GetPrecio());
                    $hamburguesaAux->SumarStock($hamburguesaAComparar->GetStock());
                    return true;
                }
            }
        } else return false;
    }

    public static function UltimoIdRegistrado(){
        $arrayDeHamburguesas = self::LeerHamburguesasJSON();
        $maximo = 0;
        if (count($arrayDeHamburguesas) > 0){
            foreach ($arrayDeHamburguesas as $hamburguesa){
                if ($hamburguesa->GetId() > $maximo){
                    $maximo = $hamburguesa->GetId();
                }
            }
        }
        return $maximo;
    }

    public function GuardarImagenHamburguesa(){
        $dir = 'ImagenesDeHamburguesas/';
        if (!file_exists($dir))
        {
            mkdir($dir, 0777, true);
        }
        $this->SetNombreFoto();
        $extension = pathinfo($_FILES["image"]["name"], PATHINFO_EXTENSION);
        $destino = $dir . $this->GetNombreFoto() . "." . $extension;
        $tipoArchivo = pathinfo($destino, PATHINFO_EXTENSION);
        if ($tipoArchivo != 'jpg' && $tipoArchivo != 'png' && $tipoArchivo != 'bmp')
        {
            echo 'Sólo se aceptan imagenes JPG, PNG y BMP!';
            return false;
        } else{
            return move_uploaded_file($_FILES["image"]["tmp_name"], $destino);
        }
    }

    public static function ConsultarExistencia($hamburguesaParam){
        $arrayDeHamburguesas = self::LeerHamburguesasJSON();
        if (count($arrayDeHamburguesas) > 0 && is_a($hamburguesaParam, "Hamburguesa")){
            $existeNombre = false;
            $existeTipo = false;
            foreach ($arrayDeHamburguesas as $hamburguesa){
                if ($hamburguesa->GetNombre() == $hamburguesaParam->GetNombre()){
                    $existeNombre  = true;
                    break;
                }
            }
            foreach ($arrayDeHamburguesas as $hamburguesa){
                if ($hamburguesa->GetNombre() == $hamburguesaParam->GetNombre() && $hamburguesa->GetTipo() == $hamburguesaParam->GetTipo()){
                    $existeTipo = true;
                    break;
                }
            }
            if ($existeNombre && $existeTipo){
                $mensaje = 1;
            }
            else if ($existeNombre && !$existeTipo){
                $mensaje = 2;
            } else if (!$existeNombre){
                $mensaje = 3;
            }
            return $mensaje;
        } else return -1;
    }

    public static function ObtenerHamburguesa($hamburguesaAComparar){
        $arrayDeHamburguesas = self::LeerHamburguesasJSON();
        if (count($arrayDeHamburguesas) > 0 && is_a($hamburguesaAComparar, "Hamburguesa")){
            foreach($arrayDeHamburguesas as $hamburguesaAux){
                if ($hamburguesaAux->Equals($hamburguesaAComparar)){
                    return $hamburguesaAux;
                }
            }
        }
        return null;
    }
}
?>