<?php
class Cupon{
    public $id;
    public $porcentajeDescuento;
    public $estado;
    public $idDevolucion;

    public function __construct($id, $descuento, $estado = "no usado", $id_devolucion){
        if (is_int($descuento) && $descuento > 0 && $descuento <= 100){
            $this->porcentajeDescuento = $descuento;
        }
        if (is_int($id)){
            $this->id = $id;
        }
        if (is_string($estado) && ($estado == "usado" || $estado == "no usado")){
            $this->estado = $estado;
        } else $this->estado = "no usado";
        if (is_int($id_devolucion)){
            $this->idDevolucion = $id_devolucion;
        }
    }

    public function GetId(){
        return $this->id;
    }

    public function GetEstado(){
        return $this->estado;
    }

    public function SetEstado($value){
        if (!empty($value)){
            $this->estado = $value;
        }
    }

    public static function GuardarCupon($cupon){
        $arrayDecupones = self::LeercuponesJSON();
        array_push($arrayDecupones, $cupon);
        return JSON::EscrituraJson("cupones.json", $arrayDecupones);
    }

    public static function LeerCuponesJSON($arrayDeCupones = array()){
        $datosJson = JSON::LecturaJson("cupones.json");
        if (!empty($datosJson))
        {
            for ($i = 0; $i < count($datosJson); $i++){
                $cupon = new Cupon(
                intval($datosJson[$i]["id"]),
                intval($datosJson[$i]["porcentajeDescuento"]),
                $datosJson[$i]["estado"],
                intval($datosJson[$i]["idDevolucion"]));
                array_push($arrayDeCupones, $cupon);
            }
        }
        return $arrayDeCupones;
    }

    public static function UltimoIdRegistrado(){
        $arrayDeCupones = self::LeerCuponesJSON();
        $maximo = 0;
        if (count($arrayDeCupones) > 0){
            foreach ($arrayDeCupones as $cupon){
                if ($cupon->GetId() > $maximo){
                    $maximo = $cupon->GetId();
                }
            }
        }
        return $maximo;
    }

    public static function UtilizarCupon($idParam){
        $arrayDeCupones = self::LeerCuponesJSON();
        $utilizado = false;
        if (count($arrayDeCupones) > 0){
            foreach($arrayDeCupones as $cuponArray){
                if ($cuponArray->GetEstado() == "no usado" && $cuponArray->GetId() == $idParam){
                    $cuponArray->SetEstado("usado");
                    $utilizado = true;
                    break;
                }
            }
            JSON::EscrituraJson("cupones.json", $arrayDeCupones);
        }
        return $utilizado;
    }

    public static function MostrarTablaCupones(){
        $arrayDeCupones = self::LeerCuponesJSON();
        $strCuponesTotales = "<h4 align='center'> Cupones </h4>";
        $strCuponesTotales .= "<table align='center'><thead><tr><th>ID</th><th>Descuento</th><th>Estado</th><th>ID Devolucion</th></tr><tbody>";
        if (count($arrayDeCupones) > 0){
            foreach ($arrayDeCupones as $cuponArray){
                $strCuponesTotales .= "<tr align='center'>" .
                "<td>" . $cuponArray->GetId() . "</td>" .
                "<td>" . $cuponArray->porcentajeDescuento . "%</td>" .
                "<td>" . $cuponArray->GetEstado() . "</td>" .
                "<td>" . $cuponArray->idDevolucion . "</td></tr>";
            }
        }
        $strCuponesTotales .= "</tbody></table>";
        return $strCuponesTotales;
    }
}
?>