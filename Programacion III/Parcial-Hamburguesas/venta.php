<?php
require_once "json.php";
date_default_timezone_set("America/Argentina/Buenos_Aires");
class Venta{
    public $email;
    public $cantidad;
    public $nombre;
    public $tipo;
    public $fecha;
    public $id;
    public $eliminado;
    public $importeFinal;
    private $nombreFoto;

    public function __construct($email, $cantidad, $nombre, $tipo, $fecha, $id = 0, $nombreFoto = "", $eliminado = false, $importeFinal = 0){
        if (is_string($email)){
            $this->email = $email;     
        }
        if (is_string($tipo)){
            $this->tipo = $tipo;
        }
        if (is_int($cantidad)){
            $this->cantidad = $cantidad;
        }
        if (is_string($nombre)){
            $this->nombre = $nombre;
        }
        if (date_parse($fecha)){
            $this->fecha = $fecha;
        } else $this->fecha = date("Y-n-j");
        $this->id = $id;
        $this->nombreFoto = $nombreFoto;
        $this->eliminado = $eliminado;
        $this->importeFinal = $importeFinal;
    }

    public static function GenerarImporteFinal($cantidad, $valor, $descuento){
        if (is_int($cantidad) && is_float($valor) && is_bool($descuento)){
            $valorBruto = $valor * $cantidad;
            if (!$descuento){
                return $valorBruto;
            }
            return $valorBruto - floatval($valorBruto * 0.1);
        }
    }

    public function GetEmail(){
        return $this->email;
    }

    public function SetEmail($value){
        if (!empty($value)){
            $this->email = $value;
        }
    }

    public function GetNombre(){
        return $this->nombre;
    }

    public function SetNombre($value){
        if (!empty($value)){
            $this->nombre = $value;
        }
    }

    public function GetTipo(){
        return $this->tipo;
    }

    public function SetTipo($value){
        if (!empty($value)){
            $this->tipo = $value;
        }
    }

    public function GetFecha(){
        return $this->fecha;
    }

    public function GetPedido(){
        return $this->id;
    }

    public function GetCantidad(){
        return $this->cantidad;
    }

    public function SetCantidad($value){
        if (!empty($value)){
            $this->cantidad = $value;
        }
    }
    
    public function SetNombreFoto(){
        $this->nombreFoto = $this->tipo . "-" . $this->nombre . "-" . explode("@", $this->email)[0] . '-' . strval($this->GetFecha());
    }
    
    public function GetNombreFoto(){
        if (!isset($this->nombreFoto) || empty($this->nombreFoto)){
            $this->SetNombreFoto();
            return $this->nombreFoto;
        } else return $this->nombreFoto;  
    }
    
    public function GetEstado(){
        return $this->eliminado;
    }
    
    public function SetEstado($value){
        if (!empty($value) && is_bool($value)){
            $this->eliminado = $value;
        }
    }

    public static function RealizarVenta($venta){
        if (is_a($venta, "Venta")){
            $arrayDeVentas = self::LeerVentasJson();
            array_push($arrayDeVentas, $venta);
            JSON::EscrituraJson("venta.json", $arrayDeVentas);
            $hamburguesaAModificar = Hamburguesa::ObtenerHamburguesa(new Hamburguesa($venta->GetNombre(), 0.00, $venta->GetTipo(), 0, 0));
            if (!is_null($hamburguesaAModificar)){
                $hamburguesaAModificar->SetStock($venta->GetCantidad() * -1);
                Hamburguesa::GuardarHamburguesa($hamburguesaAModificar);
                if (!is_null($_FILES["image"]["name"])){
                    $venta->GuardarImagenVenta();
                    return "Se ha realizado la venta correctamente.";
                } else return "Se ha realizado la venta correctamente. No se ha localizado una imagen.";
            }
        }
        return "El objeto enviado no es una venta.";
    }

    public static function LeerVentasJson($arrayDeVentas = array()){
        $datosJson = JSON::LecturaJson("venta.json");
        if (!empty($datosJson)){
            for ($i = 0; $i < count($datosJson); $i++){
                $venta = new Venta(
                $datosJson[$i]["email"],
                intval($datosJson[$i]["cantidad"]),
                $datosJson[$i]["nombre"],
                $datosJson[$i]["tipo"],
                $datosJson[$i]["fecha"],
                intval($datosJson[$i]["id"]),
                "",
                boolval($datosJson[$i]["eliminado"]),
                floatval($datosJson[$i]["importeFinal"])
                );
                array_push($arrayDeVentas, $venta);
            }
        }
        return $arrayDeVentas;
    }

    public static function UltimoIdRegistrado(){
        $arrayDeVentas = self::LeerVentasJson();
        $maximo = 0;
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                if ($ventaArray->GetPedido() > $maximo && $ventaArray->GetEstado() == false){
                    $maximo = $ventaArray->GetPedido();
                }
            }
        }
        return $maximo;
    }

    public function GuardarImagenVenta(){
        $dir = "ImagenesDeLaVenta/";
        if (!file_exists($dir)){
            mkdir($dir, 0777, true);
        }
        $this->SetNombreFoto();
        $extension = pathinfo($_FILES["image"]["name"], PATHINFO_EXTENSION);
        $destino = $dir . $this->nombreFoto . "." . $extension;
        $tipoArchivo = pathinfo($destino, PATHINFO_EXTENSION);
        if ($tipoArchivo != "jpg" && $tipoArchivo != "png" && $tipoArchivo != "bmp" || is_null($_FILES["image"]["name"]))
        {
            return false;
        } else return move_uploaded_file($_FILES["image"]["tmp_name"], $destino);
    }

    public static function VentaFechaEspecifica($fecha = ""){
        if (empty($fecha) || is_null($fecha)){
           $fecha = date('Y-n-j', time() - 60 * 60 * 24);
        }
        $arrayDeVentas = self::LeerVentasJson();
        $arrayResultado = array();
        if (count($arrayDeVentas) > 0){
            foreach ($arrayDeVentas as $ventaArray){
                if ($ventaArray->GetFecha() == $fecha && $ventaArray->GetEstado() == false){
                    array_push($arrayResultado, $ventaArray);
                }
            }
        }
        return $arrayResultado;
    }

    public static function VentasSegunFecha($fechaInicio, $fechaFin){
        $arrayDeVentas = self::LeerVentasJson();
        $arrayResultado = array();
        if (count($arrayDeVentas) > 0){
            foreach ($arrayDeVentas as $ventaArray){
                if (strtotime($ventaArray->GetFecha()) >= strtotime($fechaInicio)
                 && strtotime($ventaArray->GetFecha()) <= strtotime($fechaFin) 
                 && $ventaArray->GetEstado() == false){
                    array_push($arrayResultado, $ventaArray);
                }
            }
        }
        return $arrayResultado;
    }

    public static function VentasSegunUsuario($email){
        $arrayDeVentas = self::LeerVentasJson();
        $arrayResultado = array();
        if (count($arrayDeVentas) > 0){
            foreach ($arrayDeVentas as $ventaArray){
                if ($ventaArray->GetEmail() == $email && $ventaArray->GetEstado() == false){
                    array_push($arrayResultado, $ventaArray);
                }
            }
        }
        return $arrayResultado;
    }

    public static function VentasSegunTipo($tipo){
        $arrayDeVentas = self::LeerVentasJson();
        $arrayResultado = array();
        if (count($arrayDeVentas) > 0){
            foreach ($arrayDeVentas as $ventaArray){
                if ($ventaArray->GetTipo() == $tipo && $ventaArray->GetEstado() == false){
                    array_push($arrayResultado, $ventaArray);
                }
            }
        }
        return $arrayResultado;
    }
    public static function ModificarVenta($numeroPedido, $emailUsuario, $nombre, $tipo, $cantidad){
        $modificacion = false;
        $arrayDeVentas = self::LeerVentasJson();
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                if ($ventaArray->GetPedido() == $numeroPedido && $ventaArray->GetEstado() == false){
                    $datosAuxBurger = ["nombre" => $ventaArray->GetNombre(), "tipo" => $ventaArray->GetTipo(), "cantidad" => $ventaArray->GetCantidad()];
                    $ventaArray->SetNombre($nombre);
                    $ventaArray->SetEmail($emailUsuario);
                    $ventaArray->SetTipo($tipo);
                    $ventaArray->SetCantidad($cantidad);
                    $modificacion = true;
                    break;
                }
            }
            if ($modificacion){
                JSON::EscrituraJson("venta.json", $arrayDeVentas);
                require_once "hamburguesa.php";
                $arrayDeHamburguesas = Hamburguesa::LeerHamburguesasJSON();
                $hamburguesaParam = new Hamburguesa($datosAuxBurger["nombre"], 0.00, $datosAuxBurger["tipo"], 0);
                if (count($arrayDeHamburguesas) > 0){
                    foreach ($arrayDeHamburguesas as $hamburguesaArray){
                        if ($hamburguesaArray->GetTipo() == $datosAuxBurger["tipo"] && $hamburguesaArray->GetNombre() == $datosAuxBurger["nombre"]){
                            $hamburguesaArray->SumarStock($datosAuxBurger["cantidad"]);
                            break;
                        }
                    }
                    foreach ($arrayDeHamburguesas as $hamburguesaArray){
                        if ($hamburguesaArray->GetTipo() == $tipo && $hamburguesaArray->GetNombre() == $nombre){
                            $hamburguesaArray->SumarStock($cantidad * -1);
                            break;
                        }
                    }
                    JSON::EscrituraJson("hamburguesas.json", $arrayDeHamburguesas);
                    return "Se ha modificado la venta exitosamente. Se han actualizado el stock de las hamburguesas.";
                }
            }
        }
        return "No se ha podido realizar la modificación.";
    }

    public static function BorrarVenta($numeroPedido){
        $arrayDeVentas = self::LeerVentasJson();
            for ($i = 0; $i < count($arrayDeVentas); $i++){
                if ($arrayDeVentas[$i]->GetPedido() == $numeroPedido){
                    $arrayDeVentas[$i]->SetNombreFoto();
                    if ($arrayDeVentas[$i]->BackupImagenes($arrayDeVentas[$i]->GetNombreFoto())){
                        $arrayDeVentas[$i]->SetEstado(true);
                        JSON::EscrituraJson("venta.json", $arrayDeVentas);
                        return "Se ha eliminado correctamente la venta.";
                    }
                }
            }
        return "No se ha podido eliminar la venta solicitada.";
    }

    public function BackupImagenes($nombreFotoAntigua){
        $dirAntigua = "./ImagenesDeLaVenta/" . $nombreFotoAntigua;
        $dirNueva = "./BACKUPVENTAS/";
        if (!file_exists($dirNueva)){
            mkdir($dirNueva, 0777, true);
        }
        if (file_exists($dirAntigua . ".bmp")){
            $nombreFotoAntigua .= ".bmp";
        } else if (file_exists($dirAntigua . ".png")){
            $nombreFotoAntigua .= ".png";
        } else{
            if (empty($nombreFotoAntigua) || is_null($nombreFotoAntigua)){
                return false;
            }
            $nombreFotoAntigua .= ".jpg";
        }
        return rename("./ImagenesDeLaVenta/" . $nombreFotoAntigua, $dirNueva . $nombreFotoAntigua);
    }

    public static function VerificarPedido($pedido){
        $arrayDeVentas = self::LeerVentasJson();
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                if ($ventaArray->GetPedido() == $pedido && $ventaArray->GetEstado() == false){
                    return true;
                }
            }
        }
        return false;
    }
}
?>