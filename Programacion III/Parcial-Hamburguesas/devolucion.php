<?php
require_once "cupon.php";
require_once "json.php";
class Devolucion{
    public $id;
    public $idPedido;
    public $razonDevolucion;
    public $idCupon;

    public function __construct($idDevolucion, $id_pedido, $razonDevolucion, $id_cupon){
        $this->id = $idDevolucion;
        if (is_int($id_pedido)){
            $this->idPedido = $id_pedido;
        }
        if (is_string($razonDevolucion)){
            $this->razonDevolucion = $razonDevolucion;
        }        
        $this->idCupon = $id_cupon;
    }

    public static function GenerarCupon($devolucion_id){
        $cuponGenerado = new Cupon(Cupon::UltimoIdRegistrado() + 1, 10, "no usado", $devolucion_id);
        Cupon::GuardarCupon($cuponGenerado);
        return $cuponGenerado->GetId();
    }

    public function GetPedido(){
        return $this->idPedido;
    }

    public function GetRazon(){
        return $this->razonDevolucion;
    }

    public function GetId(){
        return $this->id;
    }

    public function GetCuponId(){
        return $this->idCupon;
    }

    public static function GuardarDevolucion($devolucion){
        $arrayDeDevoluciones = self::LeerDevolucionesJSON();
        array_push($arrayDeDevoluciones, $devolucion);
        JSON::EscrituraJson("devoluciones.json", $arrayDeDevoluciones);
        return "Se ha registrado la devolución del producto.";
    }

    public static function LeerDevolucionesJSON($arrayDeDevoluciones = array()){
        $datosJson = JSON::LecturaJson("devoluciones.json");
        if (!empty($datosJson)){
            for ($i = 0; $i < count($datosJson); $i++){
                $devolucion = new Devolucion(
                intval($datosJson[$i]["id"]),
                intval($datosJson[$i]["idPedido"]),
                $datosJson[$i]["razonDevolucion"],
                intval($datosJson[$i]["idCupon"])
                );
                array_push($arrayDeDevoluciones, $devolucion);
            }
        }
        return $arrayDeDevoluciones;
    }

    public static function UltimoIdRegistrado(){
        $arrayDeDevoluciones = self::LeerDevolucionesJSON();
        $maximo = 0;
        if (count($arrayDeDevoluciones) > 0){
            foreach ($arrayDeDevoluciones as $devolucion){
                if ($devolucion->GetId() > $maximo){
                    $maximo = $devolucion->GetId();
                }
            }
        }
        return $maximo;
    }
    
    public static function MostrarTablaDevoluciones(){
        $arrayDeDevoluciones = self::LeerDevolucionesJSON();
        $strDevolucionesTotales = "<h4 align='center'> Devoluciones </h4>";
        $strDevolucionesTotales .= "<table align='center'><thead><tr><th>ID</th><th>N° Pedido</th><th>Razon</th><th>Cupon ID</th></tr><tbody>";
        if (count($arrayDeDevoluciones) > 0){
            foreach ($arrayDeDevoluciones as $devolucion){
                $strDevolucionesTotales .= "<tr align='center'>" .
                "<td>" . $devolucion->GetId() . "</td>" .
                "<td>" . $devolucion->GetPedido() . "</td>" .
                "<td>" . $devolucion->GetRazon() . "</td>" .
                "<td>" . $devolucion->GetCuponId() . "</td></tr>";
            }
        }
        $strDevolucionesTotales .= "</tbody></table>";
        return $strDevolucionesTotales;
    }
}
?>