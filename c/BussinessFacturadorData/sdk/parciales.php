<?php
/**
 * @author MultiFacturas.com
 * @copyright 2014
 * 
 * EL array $datos contiene la información de la factura a generar
 * 
 * GENERA EL XML Y LO TIMBRA EN BASE A LA INFORMACION DEL ARREGLO $datos
 * 
 * VALIDADOR DE ESTRUCTURA DEL XML
 * https://www.consulta.sat.gob.mx/sicofi_web/moduloECFD_plus/ValidadorCFDI/Validador%20cfdi.html
 * 
 * PARA NOTA DE CREDITO SOLO CAMBIA EL PARAMETRO $datos['factura']['tipocomprobante'] a egreso
 * 
 * EN ALGUNOS EJEMPLOS SON ILUSTRATIVOS DE LOS PARAMETROS, ASI QUE LOS MONTOS NO CONCORDARAN
 * 
 */

error_reporting(0); // OPCIONAL DESACTIVA NOTIFICACIONES DE DEBUG
date_default_timezone_set('America/Mexico_City');

include_once "lib/cfdi32_multifacturas.php";

/////////////////////////////////////////////////////////////////////////////////
////////////     CREAR ARCHIVOS .PEM
/////////////////////////////////////////////////////////////////////////////////


$datos['PAC']['usuario'] = 'DEMO700101XXX';
$datos['PAC']['pass'] = 'DEMO700101XXX';
$datos['PAC']['produccion'] = 'NO'; //   [SI|NO]
$datos['conf']['cer'] = 'pruebas/aaa010101aaa.cer.pem';
$datos['conf']['key'] = 'pruebas/aaa010101aaa.key.pem';
$datos['conf']['pass'] = '12345678a';



//RUTA DONDE ALMACENARA EL CFDI
$datos['cfdi']='timbrados/cfdi_ejemplo_factura_parcialescontruccion.xml';
// OPCIONAL GUARDAR EL XML GENERADO ANTES DE TIMBRARLO
$datos['xml_debug']='timbrados/sin_timbrar_ejemplo_factura_parcialescontruccion.xml';

//OPCIONAL, ACTIVAR SOLO EN CASO DE CONFLICTOS
$datos['remueve_acentos']='SI';

//OPCIONAL, UTILIZAR LA LIBRERIA PHP DE OPENSSL, DEFAULT SI
$datos['php_openssl']='SI';

$datos['factura']['serie'] = 'A'; //opcional
$datos['factura']['folio'] = '27'; //opcional
$datos['factura']['fecha_expedicion'] = '2016-11-17 15:11:37';


$datos['factura']['metodo_pago'] = '01'; // EFECTIV0, CHEQUE, TARJETA DE CREDITO, TRANSFERENCIA BANCARIA, NO IDENTIFICADO
$datos['factura']['forma_pago'] = 'PAGO EN UNA SOLA EXHIBICION';  //PAGO EN UNA SOLA EXHIBICION, CREDITO 7 DIAS, CREDITO 15 DIAS, CREDITO 30 DIAS, ETC
$datos['factura']['tipocomprobante'] = 'ingreso'; //ingreso, egreso
$datos['factura']['moneda'] = 'MXN'; // MXN USD EUR
$datos['factura']['tipocambio'] = '1.0000'; // OPCIONAL (MXN = 1.00, OTRAS EJ: USD = 13.45; EUR = 16.86)
$datos['factura']['LugarExpedicion'] = 'SAN JUAN DEL RIO,QUERETARO';
//$datos['factura']['NumCtaPago'] = '0234'; //opcional; 4 DIGITOS pero obligatorio en transferencias y cheques

$datos['factura']['RegimenFiscal'] = 'Regimen de Incorporacion Fiscal';
$datos['factura']['subtotal'] = '123.00';
$datos['factura']['descuento'] = '0.00';
$datos['factura']['total'] = '142.68';


$datos['emisor']['rfc'] = 'AAA010101AAA'; //RFC DE PRUEBA  
$datos['emisor']['nombre'] = 'DEMO CUCC PREPAGO';  // EMPRESA DE PRUEBA
$datos['emisor']['DomicilioFiscal']['calle'] = 'MONTE LIBANO';
$datos['emisor']['DomicilioFiscal']['noExterior'] = '85';
$datos['emisor']['DomicilioFiscal']['noInterior'] = ''; //(opcional)
$datos['emisor']['DomicilioFiscal']['colonia'] = 'LOMAS DE SAN JUAN SECCION CAMPESTRE';
$datos['emisor']['DomicilioFiscal']['localidad'] = '';
$datos['emisor']['DomicilioFiscal']['municipio'] = 'SAN JUAN DEL RIO'; // o delegacion
$datos['emisor']['DomicilioFiscal']['estado'] = 'QUERETARO';
$datos['emisor']['DomicilioFiscal']['pais'] = 'MEXICO';
$datos['emisor']['DomicilioFiscal']['CodigoPostal'] = '76808'; // 5 digitos

//SI EX EXPEDIDO EN SUCURSAL CAMBIA EL DOMICILIO
//SI ES EN EL MISMO DOMICILIO REPETIR INFORMACION
$datos['emisor']['ExpedidoEn']['calle'] = 'LAS FLORES';
$datos['emisor']['ExpedidoEn']['noExterior'] = '3';
$datos['emisor']['ExpedidoEn']['noInterior'] = ''; //(opcional)
$datos['emisor']['ExpedidoEn']['colonia'] = 'COL MEXICO';
$datos['emisor']['ExpedidoEn']['localidad'] = '';
$datos['emisor']['ExpedidoEn']['municipio'] = 'SAN JUAN DEL RIO'; // O DELEGACION
$datos['emisor']['ExpedidoEn']['estado'] = 'QUERETARO';
$datos['emisor']['ExpedidoEn']['pais'] = 'MEXICO';
$datos['emisor']['ExpedidoEn']['CodigoPostal'] = '76800'; // 5 digitos

// IMPORTANTE PROBAR CON NOMBRE Y RFC REAL O GENERARA ERROR DE XML MAL FORMADO
$datos['receptor']['rfc'] = 'QUHJ711021UR1';
$datos['receptor']['nombre'] = 'JAIME AGUSTIN QUINTANAR HELGUEROS';
//opcional
$datos['receptor']['Domicilio']['calle'] = '20 DE NOVIEMBRE';
$datos['receptor']['Domicilio']['noExterior'] = '125';
$datos['receptor']['Domicilio']['noInterior'] = '';
$datos['receptor']['Domicilio']['colonia'] = 'CENTRO';
$datos['receptor']['Domicilio']['localidad'] = '.';
$datos['receptor']['Domicilio']['municipio'] = 'SAN JUAN DEL RIO';
$datos['receptor']['Domicilio']['estado'] = 'QUERETARO';
$datos['receptor']['Domicilio']['pais'] = 'MEXICO';
$datos['receptor']['Domicilio']['CodigoPostal'] = '76800'; // 5 digitos

//AGREGAR 10 CONCEPTOS DE PRUEBA
for ($i = 1; $i < 2; $i++) {
    unset($concepto);
    $concepto['cantidad'] = 1;
    $concepto['unidad'] = 'PIEZA';
    $concepto['ID'] = "1980"; //ID, REF, CODIGO O SKU DEL PRODUCTO
    $concepto['descripcion'] = "ejemplo";
    $concepto['valorunitario'] = '123.00'; // SIN IVA
    $concepto['importe'] = '123.00';

    $datos['conceptos'][] = $concepto;
}



$translado1['impuesto'] = 'IVA';
$translado1['tasa'] = '16';
$translado1['importe'] = 19.68; // iva de los productos facturados
$datos['impuestos']['translados'][0] = $translado1;


//COMPLEMENTO INE
    $datos['factura']['TipoProceso']='Precampaña'; //Ordinario/Precampaña/Campaña
//    $datos['factura']['TipoComite']='Ejecutivo Estatal';//opcional
//    $datos['factura']['IdContabilidad']='123456';//opcional
    

    $datos['parcialesconstruccion']['NumPerLicoAut']='23423432';
    $datos['parcialesconstruccion']['Inmueble']['Calle']='20 de noviembre';
    $datos['parcialesconstruccion']['Inmueble']['NoExterior']='22';
    $datos['parcialesconstruccion']['Inmueble']['NoInterior']='';
    $datos['parcialesconstruccion']['Inmueble']['Colonia']='centro';
    $datos['parcialesconstruccion']['Inmueble']['Localidad']='';
    $datos['parcialesconstruccion']['Inmueble']['Referencia']='enfrente de un ciber';
    $datos['parcialesconstruccion']['Inmueble']['Municipio']='san juan del rio';
    $datos['parcialesconstruccion']['Inmueble']['Estado']='22';
    $datos['parcialesconstruccion']['Inmueble']['CodigoPostal']='76800';



$res= cfdi_generar_xml($datos);


///////////    MOSTRAR RESULTADOS DEL ARRAY $res   ///////////
 
echo "<h1>Respuesta Generar XML y Timbrado</h1>";
foreach($res AS $variable=>$valor)
{
    $valor=htmlentities($valor);
    $valor=str_replace('&lt;br/&gt;','<br/>',$valor);
    echo "<b>[$variable]=</b>$valor<hr>";
}



?>