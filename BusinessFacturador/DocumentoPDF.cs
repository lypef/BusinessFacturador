﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

using System.Xml;
using System.Globalization;

namespace DocumentoPDF
{
    public class Emisor
    {

        public string rfc = string.Empty;
        public string razonSocial = string.Empty;
        public string calle = string.Empty;
        public string numeroExterior = string.Empty;
        public string numeroInterior = string.Empty;
        public string colonia = string.Empty;
        public string localidad = string.Empty;
        public string municipio = string.Empty;
        public string estado = string.Empty;
        public string pais = string.Empty;
        public string cp = string.Empty;
        public string telefono = string.Empty;

        public string Nombre { get; internal set; }
        public string RegimenFiscal { get; internal set; }
        public string usocfdi { get; internal set; }
    }

    public class ProductoCFD
    {

        public string cantidad = string.Empty;
        public string descripcion = string.Empty;
        public string unidad = string.Empty;
        public float valorUnitario = 0.00f;
        public float importe = 0.00f;
        public string numIdentificacion = string.Empty;

        public string ClaveProducto { get; internal set; }
        public string id { get; internal set; }
        public string c_unidad { get; internal set; }
        public string desc { get; internal set; }
        public string v_unitario { get; internal set; }
        public string descuento { get; internal set; }
    }

    public class ImpuestoCFD
    {
        public string impuesto;
        public float tasa;
        public float importe;
    }

    public class RetencionCFD
    {
        public string impuesto;
        public float importe;
    }

    public class DocumentoPDF
    {
        public string serie = string.Empty;
        public string folio = string.Empty;
        public string folioFiscalUUID = string.Empty;
        public string noSerieCertificadoSAT = string.Empty;
        public string noSerieCertificadoEmisor = string.Empty;
        public string fechaCertificacion = string.Empty;
        public string fechaEmisionCFDI = string.Empty;

        public string regimenFiscal = string.Empty;
        public string lugarExpedicion = string.Empty;
        public string formaPago = string.Empty;
        public string metodoPago = string.Empty;
        public string claveMoneda = string.Empty;

        public string selloDigitalCFDI = string.Empty;
        public string selloDigitalSAT = string.Empty;
        public string cadenaOriginal = string.Empty;

        public float subtotal = 0.00f;
        public float total = 0.00f;
        public float descuento = 0.00f;

        public string fechaExpedicion = string.Empty;

        public Emisor emisor = new Emisor();
        public Emisor receptor = new Emisor();
        public List<ProductoCFD> productos = new List<ProductoCFD>();
        public List<ImpuestoCFD> impuestos = new List<ImpuestoCFD>();
        public List<RetencionCFD> retenciones = new List<RetencionCFD>();

        public string totalEnLetra = string.Empty;
        public float totalImpuestosRetenidos = 0.00f;

        public string tipo_cambio { get; internal set; }
    }

    public class CreaPDF
    {
        private Document _documento; //Objeto para escribir el pdf
        BaseFont _fuenteTitulos = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
        BaseFont _fuenteContenido = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
        PdfWriter _writer;
        PdfContentByte _cb;
        DocumentoPDF _templatePDF; //Objeto que contendra la información del documento pdf
        XmlDocument xDoc; // Objeto para abrir el archivo xml

        public CreaPDF(string rutaXML, string rutaPDF, System.Drawing.Image logo)
        {

            LeerArtributosXML(rutaXML);

            //Trabajos con el documento XML
            _documento = new Document(PageSize.LETTER);
            //string nombreDocumento = Path.GetTempFileName() + ".pdf";
            string nombreDocumento = rutaPDF;

            //Creamos el documetno
            _writer = PdfWriter.GetInstance(_documento, new FileStream(nombreDocumento, FileMode.Create));
            _writer.PageEvent = new ITextEvents();

            //Agregamos propiedades al documento
            AgregaPropiedadesDocumento();

            //Abrimos el documento
            _documento.Open();


            AgregarLogo(logo);
            AgregarCuadro();
            AgregarDatosEmisor();
            AgregarDatosFactura();
            AgregarDatosReceptorEmisor();
            AgregarDatosProductos();
            AgregarTotales();
            AgregarSellos();

            //Cerramoe el documento
            _documento.Close();

            //Abrimos el archivo .pdf
            System.Diagnostics.Process.Start(nombreDocumento);
        }

        #region Leer datos del .xml

        private void LeerArtributosXML(string rutaXML)
        {
            xDoc = new XmlDocument(); //Instancia documento pdf
            _templatePDF = new DocumentoPDF(); //Instancia que contendrá la información para llenar el pdf
            xDoc.Load(rutaXML);
            ObtenerNodoCfdiComprobante();
            ObtenerNodoEmisor();
            ObtenerNodoReceptor();
            ObtenerNodoConceptos();
            ObtenerNodoComplementoDigital();
            ObtenerNodoImpuestos();

        }

        private void ObtenerNodoCfdiComprobante()
        {
            float valFloat;
            if (xDoc.GetElementsByTagName("cfdi:Comprobante") == null)
                return;

            XmlNodeList comprobante = xDoc.GetElementsByTagName("cfdi:Comprobante");
            if (((XmlElement)comprobante[0]).GetAttribute("Serie") != null)
                _templatePDF.serie = ((XmlElement)comprobante[0]).GetAttribute("Serie");
            if (((XmlElement)comprobante[0]).GetAttribute("Folio") != null)
                _templatePDF.folio = ((XmlElement)comprobante[0]).GetAttribute("Folio");
            if (((XmlElement)comprobante[0]).GetAttribute("Fecha") != null)
                _templatePDF.fechaEmisionCFDI = ((XmlElement)comprobante[0]).GetAttribute("Fecha");
            if (((XmlElement)comprobante[0]).GetAttribute("Sello") != null)
                _templatePDF.selloDigitalCFDI = ((XmlElement)comprobante[0]).GetAttribute("Sello");
            if (((XmlElement)comprobante[0]).GetAttribute("NoCertificado") != null)
                _templatePDF.noSerieCertificadoEmisor = ((XmlElement)comprobante[0]).GetAttribute("NoCertificado");
            if (((XmlElement)comprobante[0]).GetAttribute("SubTotal") != null)
            {
                float.TryParse(((XmlElement)comprobante[0]).GetAttribute("SubTotal"), out valFloat);
                _templatePDF.subtotal = valFloat;
            }
            if (((XmlElement)comprobante[0]).GetAttribute("Total") != null)
            {
                float.TryParse(((XmlElement)comprobante[0]).GetAttribute("Total"), out valFloat);
                _templatePDF.total = valFloat;

                Numalet numaLet = new Numalet();
                numaLet.MascaraSalidaDecimal = "00/100 M.N.";
                numaLet.SeparadorDecimalSalida = "pesos";
                numaLet.ApocoparUnoParteEntera = true;
                numaLet.LetraCapital = true;
                _templatePDF.totalEnLetra = numaLet.ToCustomString(double.Parse(_templatePDF.total.ToString()));
            }
            if (((XmlElement)comprobante[0]).GetAttribute("Descuento") != null)
            {
                float.TryParse(((XmlElement)comprobante[0]).GetAttribute("Descuento"), out valFloat);
                _templatePDF.descuento = valFloat;
            }

            if (((XmlElement)comprobante[0]).GetAttribute("Moneda") != null)
                _templatePDF.claveMoneda = ((XmlElement)comprobante[0]).GetAttribute("Moneda");
            if (((XmlElement)comprobante[0]).GetAttribute("MetodoPago") != null)
                _templatePDF.metodoPago = ((XmlElement)comprobante[0]).GetAttribute("MetodoPago");
            if (((XmlElement)comprobante[0]).GetAttribute("FormaPago") != null)
                _templatePDF.formaPago = ((XmlElement)comprobante[0]).GetAttribute("FormaPago");
            if (((XmlElement)comprobante[0]).GetAttribute("TipoCambio") != null)
                _templatePDF.tipo_cambio = ((XmlElement)comprobante[0]).GetAttribute("TipoCambio");
        }

        private void ObtenerNodoEmisor()
        {
            //Trabajamos con Emisor
            if (xDoc.GetElementsByTagName("cfdi:Emisor") == null)
                return;
            XmlNodeList emisor = xDoc.GetElementsByTagName("cfdi:Emisor");
            _templatePDF.emisor.rfc = ((XmlElement)emisor[0]).GetAttribute("Rfc");
            _templatePDF.emisor.Nombre = ((XmlElement)emisor[0]).GetAttribute("Nombre");
            _templatePDF.emisor.RegimenFiscal = ((XmlElement)emisor[0]).GetAttribute("RegimenFiscal");
        }

        private void ObtenerNodoReceptor()
        {
            //Trabajamos con receptor
            XmlNodeList receptor = xDoc.GetElementsByTagName("cfdi:Receptor");
            _templatePDF.receptor.razonSocial = ((XmlElement)receptor[0]).GetAttribute("Nombre");
            _templatePDF.receptor.rfc = ((XmlElement)receptor[0]).GetAttribute("Rfc");
            _templatePDF.receptor.usocfdi = ((XmlElement)receptor[0]).GetAttribute("UsoCFDI");
        }

        private void ObtenerNodoConceptos()
        {
            ProductoCFD p;

            if (xDoc.GetElementsByTagName("cfdi:Conceptos") == null)
                return;
            XmlNodeList conceptos = xDoc.GetElementsByTagName("cfdi:Conceptos");

            if (((XmlElement)conceptos[0]).GetElementsByTagName("cfdi:Concepto") == null)
                return;
            XmlNodeList lista = ((XmlElement)conceptos[0]).GetElementsByTagName("cfdi:Concepto");

            foreach (XmlElement nodo in lista)
            {
                p = new ProductoCFD();

                p.ClaveProducto = nodo.GetAttribute("ClaveProdServ");
                p.id = nodo.GetAttribute("NoIdentificacion");
                p.cantidad = nodo.GetAttribute("Cantidad");
                p.c_unidad = nodo.GetAttribute("ClaveUnidad");
                p.unidad = nodo.GetAttribute("Unidad");
                p.desc = nodo.GetAttribute("Descripcion");
                p.v_unitario = nodo.GetAttribute("ValorUnitario");
                p.importe = float.Parse(nodo.GetAttribute("Importe"));
                p.descuento = "0.0";

                _templatePDF.productos.Add(p);
            }
        }

        private void ObtenerNodoComplementoDigital()
        {
            XmlNodeList tfDigital = xDoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
            if (tfDigital.Count <= 0)
                return;

            if (((XmlElement)tfDigital[0]).GetAttribute("UUID") != null)
                _templatePDF.folioFiscalUUID = ((XmlElement)tfDigital[0]).GetAttribute("UUID");
            if (((XmlElement)tfDigital[0]).GetAttribute("NoCertificadoSAT") != null)
                _templatePDF.noSerieCertificadoSAT = ((XmlElement)tfDigital[0]).GetAttribute("NoCertificadoSAT");
            if (((XmlElement)tfDigital[0]).GetAttribute("FechaTimbrado") != null)
                _templatePDF.fechaCertificacion = ((XmlElement)tfDigital[0]).GetAttribute("FechaTimbrado");
            if (((XmlElement)tfDigital[0]).GetAttribute("SelloSAT") != null)
                _templatePDF.selloDigitalSAT = ((XmlElement)tfDigital[0]).GetAttribute("SelloSAT");
        }

        private void ObtenerNodoImpuestos()
        {
            float valFloat;
            XmlNodeList impuestos = xDoc.GetElementsByTagName("cfdi:Impuestos");
            float.TryParse(((XmlElement)impuestos[0]).GetAttribute("totalImpuestosTrasladados"), out valFloat);
            _templatePDF.totalImpuestosRetenidos = valFloat;

            if (xDoc.GetElementsByTagName("cfdi:Traslados") == null)
                return;
            XmlNodeList traslados = xDoc.GetElementsByTagName("cfdi:Traslados");

            if (((XmlElement)traslados[0]).GetElementsByTagName("cfdi:Traslado") == null)
                return;
            XmlNodeList lista = ((XmlElement)traslados[0]).GetElementsByTagName("cfdi:Traslado");

            foreach (XmlElement nodo in lista)
            {
                ImpuestoCFD a = new ImpuestoCFD();
                a.impuesto = nodo.GetAttribute("impuesto");
                float.TryParse(nodo.GetAttribute("tasa"), out valFloat);
                a.tasa = valFloat;

                float.TryParse(nodo.GetAttribute("importe"), out valFloat);
                a.importe = valFloat;

                _templatePDF.impuestos.Add(a);
            }

            XmlNodeList retenciones = xDoc.GetElementsByTagName("cfdi:Retenciones");
            if (retenciones.Count > 0)
            {

                if (((XmlElement)retenciones[0]).GetElementsByTagName("cfdi:Retencion") == null)
                    return;
                XmlNodeList listaRetenciones = ((XmlElement)retenciones[0]).GetElementsByTagName("cfdi:Retencion");

                foreach (XmlElement nodo in listaRetenciones)
                {
                    RetencionCFD r = new RetencionCFD();
                    r.impuesto = nodo.GetAttribute("impuesto");
                    float.TryParse(nodo.GetAttribute("importe"), out valFloat);
                    r.importe = valFloat;
                    _templatePDF.retenciones.Add(r);
                }
            }
        }

        #endregion

        #region Escribir datos en el .pdf

        private void AgregarLogo(System.Drawing.Image logoEmpresa)
        {
            if (logoEmpresa == null)
                return;
            //Agrego la imagen al documento
            Image imagen = Image.GetInstance(logoEmpresa, BaseColor.BLACK);
            imagen.ScaleToFit(140, 140);
            imagen.Alignment = Element.ALIGN_RIGHT;
            Chunk logo = new Chunk(imagen, 1, -115);
            _documento.Add(logo);
        }

        private void AgregarCuadro()
        {
            _cb = _writer.DirectContentUnder;
            //_cb.SaveState();
            //_cb.BeginText();
            //_cb.MoveText(1, 1);
            //_cb.SetFontAndSize(_fuenteTitulos, 8);
            //_cb.ShowText("Faustino Rojas Arelano");
            //_cb.EndText();
            //_cb.RestoreState();

            //Agrego cuadro al documento
            _cb.SetColorStroke(BaseColor.BLACK); //Color de la linea
            _cb.SetColorFill(BaseColor.WHITE); // Color del relleno
            _cb.SetLineWidth(3.5f); //Tamano de la linea
            _cb.Rectangle(408, 664, 195, 120);
            _cb.FillStroke();
        }

        private void AgregarDatosEmisor()
        {
            //Datos del emisor
            Paragraph p1 = new Paragraph();
            p1.IndentationLeft = 150f;
            p1.SpacingAfter = -60;
            p1.Leading = 9;
            p1.Add(new Phrase("DATOS DEL EMISOR", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
            p1.Add("\n");
            p1.Add(new Phrase(_templatePDF.emisor.Nombre, new Font(Font.FontFamily.HELVETICA, 10)));
            p1.Add("\n");
            p1.Add(new Phrase("RFC Emisor: " + _templatePDF.emisor.rfc, new Font(Font.FontFamily.HELVETICA, 10)));
            p1.Add("\n");

            String regimen_fiscal = "";

            if (_templatePDF.emisor.RegimenFiscal == "601")
            {
                regimen_fiscal = "Regimen Fiscal: 601 General de Ley Personas Morales";
            }

            if (_templatePDF.emisor.RegimenFiscal == "603")
            {
                regimen_fiscal = "Regimen Fiscal: 603 Personas Morales con Fines no Lucrativos";
            }

            if (_templatePDF.emisor.RegimenFiscal == "605")
            {
                regimen_fiscal = "Regimen Fiscal: 605 Sueldos y Salarios e Ingresos Asimilados a Salarios";
            }

            if (_templatePDF.emisor.RegimenFiscal == "606")
            {
                regimen_fiscal = "Regimen Fiscal: 606 Arrendamiento";
            }

            if (_templatePDF.emisor.RegimenFiscal == "608")
            {
                regimen_fiscal = "Regimen Fiscal: 608 Demás ingresos";
            }

            if (_templatePDF.emisor.RegimenFiscal == "609")
            {
                regimen_fiscal = "Regimen Fiscal: 609 Consolidación";
            }

            if (_templatePDF.emisor.RegimenFiscal == "610")
            {
                regimen_fiscal = "Regimen Fiscal: 610 Residentes en el Extranjero sin Establecimiento Permanente en México";
            }

            if (_templatePDF.emisor.RegimenFiscal == "611")
            {
                regimen_fiscal = "Regimen Fiscal: 611 Ingresos por Dividendos (socios y accionistas)";
            }

            if (_templatePDF.emisor.RegimenFiscal == "612")
            {
                regimen_fiscal = "Regimen Fiscal: 612 Personas Físicas con Actividades Empresariales y Profesionales";
            }

            if (_templatePDF.emisor.RegimenFiscal == "614")
            {
                regimen_fiscal = "Regimen Fiscal: 614 Ingresos por intereses";
            }

            if (_templatePDF.emisor.RegimenFiscal == "616")
            {
                regimen_fiscal = "Regimen Fiscal: 616 Sin obligaciones fiscales";
            }
            if (_templatePDF.emisor.RegimenFiscal == "620")
            {
                regimen_fiscal = "Regimen Fiscal: 620 Sociedades Cooperativas de Producción que optan por diferir sus ingresos";
            }

            if (_templatePDF.emisor.RegimenFiscal == "621")
            {
                regimen_fiscal = "Regimen Fiscal: 621 Incorporación Fiscal";
            }

            if (_templatePDF.emisor.RegimenFiscal == "622")
            {
                regimen_fiscal = "Regimen Fiscal: 622 Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras";
            }

            if (_templatePDF.emisor.RegimenFiscal == "624")
            {
                regimen_fiscal = "Regimen Fiscal: 624 Coordinados";
            }

            if (_templatePDF.emisor.RegimenFiscal == "628")
            {
                regimen_fiscal = "Regimen Fiscal: 628 Hidrocarburos";
            }

            if (_templatePDF.emisor.RegimenFiscal == "607")
            {
                regimen_fiscal = "Regimen Fiscal: 607 Régimen de Enajenación o Adquisición de Bienes";
            }

            if (_templatePDF.emisor.RegimenFiscal == "629")
            {
                regimen_fiscal = "Regimen Fiscal: 629 De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales";
            }

            if (_templatePDF.emisor.RegimenFiscal == "630")
            {
                regimen_fiscal = "Regimen Fiscal: 630 Enajenación de acciones en bolsa de valores";
            }

            if (_templatePDF.emisor.RegimenFiscal == "615")
            {
                regimen_fiscal = "Regimen Fiscal: 615 Régimen de los ingresos por obtención de premios";
            }

            p1.Add(new Phrase(regimen_fiscal, new Font(Font.FontFamily.HELVETICA, 10)));
            p1.Add("\n");
            p1.Add("\n");
            p1.Add("\n");
            p1.Add("\n");
            if (_templatePDF.emisor.telefono != string.Empty)
            {
                p1.Add(new Phrase("Tel." + _templatePDF.emisor.telefono, new Font(Font.FontFamily.HELVETICA, 8)));
                p1.Add("\n");
            }
            _documento.Add(p1);
        }

        private void AgregaPropiedadesDocumento()
        {
            _documento.AddAuthor("FRANCISCO EDUARDO ASCENCIO DOMINGUEZ");
            _documento.AddCreator("DOCUMENTO GENERADO DESDE C#");
            _documento.AddKeywords("FACTURA CFDI");
            _documento.AddSubject("DOCUMENTO CREADO APARTIR DE UN XML");
            _documento.AddTitle("FACTURA");
            _documento.SetMargins(5, 5, 5, 5);
        }

        private void AgregarDatosFactura()
        {
            //Datos de la factura
            Paragraph p2 = new Paragraph();
            p2.IndentationLeft = 403f;
            p2.SpacingAfter = 18;
            p2.Leading = 10;
            p2.Alignment = Element.ALIGN_CENTER;

            p2.Add(new Phrase("FACTURA NÚM: " + _templatePDF.serie + " " + _templatePDF.folio, new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
            p2.Add("\n");
            p2.Add(new Phrase("FOLIO FISCAL (UUID): ", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            p2.Add("\n");
            p2.Add(new Phrase(_templatePDF.folioFiscalUUID, new Font(Font.FontFamily.HELVETICA, 8)));
            p2.Add("\n");
            p2.Add(new Phrase("NO. DE SERIE DEL CERTIFICADO DEL SAT:", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            p2.Add("\n");
            p2.Add(new Phrase(_templatePDF.noSerieCertificadoSAT, new Font(Font.FontFamily.HELVETICA, 8)));
            p2.Add("\n");
            p2.Add(new Phrase("NO. DE SERIE DEL CERTIFICADO DEL EMISOR:", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            p2.Add("\n");
            p2.Add(new Phrase(_templatePDF.noSerieCertificadoEmisor, new Font(Font.FontFamily.HELVETICA, 8)));
            p2.Add("\n");
            p2.Add(new Phrase("FECHA Y HORA DE CERTIFICACIÓN:", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            p2.Add("\n");
            p2.Add(new Phrase(_templatePDF.fechaCertificacion, new Font(Font.FontFamily.HELVETICA, 8)));
            p2.Add("\n");
            p2.Add(new Phrase("FECHA Y HORA DE EMISIÓN DE CFDI:", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            p2.Add("\n");
            p2.Add(new Phrase(_templatePDF.fechaEmisionCFDI, new Font(Font.FontFamily.HELVETICA, 8)));
            p2.Add("\n");
            _documento.Add(p2);
        }

        private void AgregarDatosReceptorEmisor()
        {
            float[] anchoColumasTablaDatosEmisorReceptor = { 180f, 420f };
            PdfPTable tablaDatosEmisorReceptor = new PdfPTable(anchoColumasTablaDatosEmisorReceptor);
            tablaDatosEmisorReceptor.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaDatosEmisorReceptor.SetTotalWidth(anchoColumasTablaDatosEmisorReceptor);
            tablaDatosEmisorReceptor.SpacingBefore = 5;
            tablaDatosEmisorReceptor.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaDatosEmisorReceptor.LockedWidth = true;

            //Datos del receptor
            float[] anchoColumnas = { 57f, 120F };
            PdfPTable tabla = new PdfPTable(anchoColumnas);
            tabla.DefaultCell.Border = Rectangle.NO_BORDER;
            tabla.SetTotalWidth(anchoColumnas);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.LockedWidth = true;
            tabla.AddCell(new Phrase("RECEPTOR: ", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tabla.AddCell(new Phrase(_templatePDF.receptor.razonSocial.ToUpper(), new Font(Font.FontFamily.HELVETICA, 8)));

            tabla.AddCell(new Phrase("RFC: ", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tabla.AddCell(new Phrase(_templatePDF.receptor.rfc, new Font(Font.FontFamily.HELVETICA, 8)));

            string usocfdi = "";
            if (_templatePDF.receptor.usocfdi == "G01")
            {
                usocfdi = "G01: Adquisición de mercancias";
            }

            if (_templatePDF.receptor.usocfdi == "G02")
            {
                usocfdi = "G02: Devoluciones, descuentos o bonificaciones";
            }

            if (_templatePDF.receptor.usocfdi == "G03")
            {
                usocfdi = "G03: Gastos en general";
            }

            if (_templatePDF.receptor.usocfdi == "I01")
            {
                usocfdi = "I01: Construcciones";
            }

            if (_templatePDF.receptor.usocfdi == "I02")
            {
                usocfdi = "I02: Mobilario y equipo de oficina por inversiones";
            }

            if (_templatePDF.receptor.usocfdi == "I03")
            {
                usocfdi = "I03: Equipo de transporte";
            }

            if (_templatePDF.receptor.usocfdi == "I04")
            {
                usocfdi = "I04: Equipo de computo y accesorios";
            }

            if (_templatePDF.receptor.usocfdi == "I05")
            {
                usocfdi = "I05: Dados, troqueles, moldes, matrices y herramental";
            }

            if (_templatePDF.receptor.usocfdi == "I06")
            {
                usocfdi = "I06: Comunicaciones telefónicas";
            }

            if (_templatePDF.receptor.usocfdi == "I08")
            {
                usocfdi = "I08: Otra maquinaria y equipo";
            }

            if (_templatePDF.receptor.usocfdi == "D01")
            {
                usocfdi = "D01: Honorarios médicos, dentales y gastos hospitalarios.";
            }

            if (_templatePDF.receptor.usocfdi == "D02")
            {
                usocfdi = "D02: Gastos médicos por incapacidad o discapacidad";
            }

            if (_templatePDF.receptor.usocfdi == "D03")
            {
                usocfdi = "D03: Gastos funerales.";
            }

            if (_templatePDF.receptor.usocfdi == "G01")
            {
                usocfdi = "G01: Adquisición de mercancias";
            }

            if (_templatePDF.receptor.usocfdi == "D05")
            {
                usocfdi = "D05: Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación).";
            }

            if (_templatePDF.receptor.usocfdi == "D06")
            {
                usocfdi = "D06: Aportaciones voluntarias al SAR.";
            }

            if (_templatePDF.receptor.usocfdi == "D07")
            {
                usocfdi = "D07: Primas por seguros de gastos médicos.";
            }

            if (_templatePDF.receptor.usocfdi == "G01")
            {
                usocfdi = "G01: Adquisición de mercancias";
            }

            if (_templatePDF.receptor.usocfdi == "D08")
            {
                usocfdi = "D08: Gastos de transportación escolar obligatoria.";
            }

            if (_templatePDF.receptor.usocfdi == "D09")
            {
                usocfdi = "D09: Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones.";
            }


            if (_templatePDF.receptor.usocfdi == "D10")
            {
                usocfdi = "D10: Pagos por servicios educativos (colegiaturas)";
            }

            if (_templatePDF.receptor.usocfdi == "P01")
            {
                usocfdi = "P01: Por definir";
            }


            tabla.AddCell(new Phrase("Uso CFDI: ", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tabla.AddCell(new Phrase(usocfdi.ToUpper(), new Font(Font.FontFamily.HELVETICA, 8)));

            //Datos del emisor
            float[] anchoColumnas1 = { 80f, 120F, 80f, 120F };
            PdfPTable tabla1 = new PdfPTable(anchoColumnas1);
            tabla1.DefaultCell.Border = Rectangle.NO_BORDER;
            tabla1.SetTotalWidth(anchoColumnas1);
            tabla1.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla1.LockedWidth = true;
            tabla1.AddCell(new Phrase("MONEDA:".ToUpper(), new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            PdfPCell celdaRegimen = new PdfPCell(new Phrase(_templatePDF.claveMoneda, new Font(Font.FontFamily.HELVETICA, 8)));
            celdaRegimen.Colspan = 3;
            celdaRegimen.Border = Rectangle.NO_BORDER;
            tabla1.AddCell(celdaRegimen);
            tabla1.AddCell(new Phrase("FORMA DE PAGO:".ToUpper(), new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            string f_pago = "";

            if (_templatePDF.formaPago == "01")
            {
                f_pago = "01: Efectivo";
            }

            if (_templatePDF.formaPago == "02")
            {
                f_pago = "02: Cheque nominativo";
            }

            if (_templatePDF.formaPago == "03")
            {
                f_pago = "03: Transferencia electrónica de fondos";
            }

            if (_templatePDF.formaPago == "04")
            {
                f_pago = "04: Tarjeta de crédito";
            }

            if (_templatePDF.formaPago == "05")
            {
                f_pago = "05: Monedero electrónico";
            }

            if (_templatePDF.formaPago == "06")
            {
                f_pago = "06: Dinero electrónico";
            }

            if (_templatePDF.formaPago == "08")
            {
                f_pago = "08: Vales de despensa";
            }

            if (_templatePDF.formaPago == "12")
            {
                f_pago = "12: Dación en pago";
            }

            if (_templatePDF.formaPago == "13")
            {
                f_pago = "13: Pago por subrogación";
            }

            if (_templatePDF.formaPago == "14")
            {
                f_pago = "14: Pago por consignación";
            }

            if (_templatePDF.formaPago == "15")
            {
                f_pago = "15: Condonación";
            }

            if (_templatePDF.formaPago == "17")
            {
                f_pago = "17: Compensación";
            }

            if (_templatePDF.formaPago == "23")
            {
                f_pago = "23: Novación";
            }

            if (_templatePDF.formaPago == "24")
            {
                f_pago = "24: Confusión";
            }

            if (_templatePDF.formaPago == "25")
            {
                f_pago = "25: Remisión de deuda";
            }

            if (_templatePDF.formaPago == "26")
            {
                f_pago = "26: Prescripción o caducidad";
            }

            if (_templatePDF.formaPago == "01")
            {
                f_pago = "01: Efectivo";
            }

            if (_templatePDF.formaPago == "27")
            {
                f_pago = "27: A satisfacción del acreedor";
            }

            if (_templatePDF.formaPago == "28")
            {
                f_pago = "28: Tarjeta de débito";
            }

            if (_templatePDF.formaPago == "29")
            {
                f_pago = "29: Tarjeta de servicios";
            }

            if (_templatePDF.formaPago == "99")
            {
                f_pago = "99: Por definir";
            }

            tabla1.AddCell(new Phrase(f_pago.ToUpper(), new Font(Font.FontFamily.HELVETICA, 8)));
            tabla1.AddCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tabla1.AddCell(new Phrase(_templatePDF.fechaExpedicion, new Font(Font.FontFamily.HELVETICA, 8)));
            tabla1.AddCell(new Phrase("METODO DE PAGO".ToUpper(), new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));

            string m_pago = "";

            if (_templatePDF.metodoPago == "PUE")
            {
                m_pago = "PUE: Pago en una sola exhibición";
            }

            if (_templatePDF.metodoPago == "PIP")
            {
                m_pago = "PIP: Pago en parcialidades o diferido";
            }

            if (_templatePDF.metodoPago == "PPD")
            {
                m_pago = "PPD: Pago en parcialidades o diferido";
            }

            tabla1.AddCell(new Phrase(m_pago.ToUpper(), new Font(Font.FontFamily.HELVETICA, 8)));
            tabla1.AddCell(new Phrase("TIPO DE CAMBIO".ToUpper(), new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tabla1.AddCell(new Phrase(ReturnClavePago(_templatePDF.tipo_cambio), new Font(Font.FontFamily.HELVETICA, 8)));
            tabla1.AddCell(new Phrase("\n\n", new Font(Font.FontFamily.HELVETICA, 8)));


            tablaDatosEmisorReceptor.AddCell(tabla);
            tablaDatosEmisorReceptor.AddCell(tabla1);
            _documento.Add(tablaDatosEmisorReceptor);
        }

        private string ReturnClavePago(string clave)
        {
            string valor = "";

            valor = clave;

            return valor.ToString().ToUpper();
        }

        private void AgregarDatosProductos()
        {
            float[] anchoColumnasTablaProductos = { 600f };
            PdfPTable tablaProductosPrincipal = new PdfPTable(anchoColumnasTablaProductos);
            //tablaProductosPrincipal.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaProductosPrincipal.SetTotalWidth(anchoColumnasTablaProductos);
            tablaProductosPrincipal.SpacingBefore = 15;
            tablaProductosPrincipal.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaProductosPrincipal.LockedWidth = true;


            //Datos de los productos
            float[] tamanoColumnas = { 60f, 60F, 50f, 70f, 170f, 75f, 60f, 75f };
            PdfPTable tablaProductosTitulos = new PdfPTable(tamanoColumnas);
            //tablaProductosTitulos.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaProductosTitulos.SetTotalWidth(tamanoColumnas);
            tablaProductosTitulos.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaProductosTitulos.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaProductosTitulos.LockedWidth = true;

            tablaProductosTitulos.AddCell(new Phrase("CLAVEPRODUCTO O SERVICIO", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaProductosTitulos.AddCell(new Phrase("NO. IDENTIFICACION", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaProductosTitulos.AddCell(new Phrase("CANTIDAD", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaProductosTitulos.AddCell(new Phrase("CLAVE UNIDAD", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaProductosTitulos.AddCell(new Phrase("DESCRIPCION", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaProductosTitulos.AddCell(new Phrase("VALOR UNITARIO", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaProductosTitulos.AddCell(new Phrase("IMPORTE", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaProductosTitulos.AddCell(new Phrase("DESCUENTO", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));



            float[] tamanoColumnasProductos = { 60f, 60F, 50f, 70f, 170f, 75f, 60f, 75f };
            PdfPTable tablaProductos = new PdfPTable(tamanoColumnas);
            //tablaProductos.SpacingBefore = 1;
            //tablaProductos.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaProductos.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaProductos.DefaultCell.BorderWidthLeft = 0.1f;
            tablaProductos.DefaultCell.BorderWidthRight = 0.0f;
            tablaProductos.DefaultCell.BorderWidthBottom = 0.0f;
            tablaProductos.DefaultCell.BorderWidthTop = 0.0f;
            tablaProductos.SetTotalWidth(tamanoColumnas);
            tablaProductos.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaProductos.LockedWidth = true;
            foreach (ProductoCFD p in _templatePDF.productos)
            {
                tablaProductos.AddCell(new Phrase(p.ClaveProducto, new Font(Font.FontFamily.HELVETICA, 8)));
                tablaProductos.AddCell(new Phrase(p.id, new Font(Font.FontFamily.HELVETICA, 8)));
                tablaProductos.AddCell(new Phrase(p.cantidad, new Font(Font.FontFamily.HELVETICA, 8)));
                tablaProductos.AddCell(new Phrase(p.c_unidad, new Font(Font.FontFamily.HELVETICA, 8)));
                tablaProductos.AddCell(new Phrase(p.desc, new Font(Font.FontFamily.HELVETICA, 8)));
                tablaProductos.AddCell(new Phrase(p.v_unitario, new Font(Font.FontFamily.HELVETICA, 8)));
                tablaProductos.AddCell(new Phrase(p.importe.ToString(), new Font(Font.FontFamily.HELVETICA, 8)));
                tablaProductos.AddCell(new Phrase(p.descuento, new Font(Font.FontFamily.HELVETICA, 8)));
            }


            PdfPCell celdaTitulos = new PdfPCell(tablaProductosTitulos);
            tablaProductosPrincipal.AddCell(celdaTitulos);
            PdfPCell celdaProductos = new PdfPCell(tablaProductos);
            celdaProductos.MinimumHeight = 300;
            tablaProductosPrincipal.AddCell(celdaProductos);
            _documento.Add(tablaProductosPrincipal);
        }

        private void AgregarTotales()
        {

            float[] anchoColumasTablaTotales = { 420f, 180f };
            PdfPTable tablaTotales = new PdfPTable(anchoColumasTablaTotales);
            tablaTotales.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaTotales.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaTotales.SetTotalWidth(anchoColumasTablaTotales);
            tablaTotales.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaTotales.LockedWidth = true;

            float[] anchoColumnas = { 110, 70f };
            PdfPTable tablaImportes = new PdfPTable(anchoColumnas);
            tablaImportes.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaImportes.SetTotalWidth(anchoColumnas);
            tablaImportes.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //tablaImportes.HorizontalAlignment = Element.ALIGN_RIGHT;
            tablaImportes.LockedWidth = true;
            if (_templatePDF.descuento > 0.00f)
            {
                float subtotal = _templatePDF.subtotal + _templatePDF.descuento;
                tablaImportes.AddCell(new Phrase("SUBTOTAL ANTES DE DESC.:", new Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)));
                tablaImportes.AddCell(new Phrase(subtotal.ToString("C"), new Font(Font.FontFamily.HELVETICA, 8)));

                tablaImportes.AddCell(new Phrase("Descuento:".ToUpper(), new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
                tablaImportes.AddCell(new Phrase(_templatePDF.descuento.ToString("C"), new Font(Font.FontFamily.HELVETICA, 8)));
            }

            tablaImportes.AddCell(new Phrase("SUBTOTAL:", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaImportes.AddCell(new Phrase(_templatePDF.subtotal.ToString("C"), new Font(Font.FontFamily.HELVETICA, 8)));

            foreach (ImpuestoCFD i in _templatePDF.impuestos)
            {
                tablaImportes.AddCell(new Phrase(i.impuesto + " " + i.tasa.ToString("F2") + "%:", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
                tablaImportes.AddCell(new Phrase(i.importe.ToString("C"), new Font(Font.FontFamily.HELVETICA, 8)));
            }

            foreach (RetencionCFD i in _templatePDF.retenciones)
            {
                tablaImportes.AddCell(new Phrase("Retencion " + i.impuesto + ": ", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
                tablaImportes.AddCell(new Phrase(i.importe.ToString("C"), new Font(Font.FontFamily.HELVETICA, 8)));
            }

            tablaImportes.AddCell(new Phrase("Total:".ToUpper(), new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
            tablaImportes.AddCell(new Phrase(_templatePDF.total.ToString("C"), new Font(Font.FontFamily.HELVETICA, 8)));

            tablaTotales.AddCell(new Phrase("IMPORTE CON LETRA: " + _templatePDF.totalEnLetra.ToUpper(), new Font(Font.FontFamily.HELVETICA, 8)));
            tablaTotales.AddCell(tablaImportes);
            _documento.Add(tablaTotales);
        }

        private void AgregarSellos()
        {
            StringBuilder cadenaOriginal = new StringBuilder();
            cadenaOriginal.Append("||");
            cadenaOriginal.Append("1.0|");
            cadenaOriginal.Append(_templatePDF.folioFiscalUUID + "|");
            cadenaOriginal.Append(_templatePDF.fechaEmisionCFDI.ToString() + "|");
            cadenaOriginal.Append(_templatePDF.selloDigitalSAT + "|");
            cadenaOriginal.Append(_templatePDF.noSerieCertificadoSAT + "||");

            float[] anchoColumnas = { 500f, 100f };
            PdfPTable tablaSellosQR = new PdfPTable(anchoColumnas);
            tablaSellosQR.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaSellosQR.SpacingBefore = 10.0f;
            tablaSellosQR.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaSellosQR.SetTotalWidth(anchoColumnas);
            //tablaSellosQR.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaSellosQR.LockedWidth = true;

            float[] anchoColumnas1 = { 500f };
            PdfPTable tablaSellos = new PdfPTable(anchoColumnas1);
            tablaSellos.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaSellos.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;
            tablaSellos.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaSellos.SetTotalWidth(anchoColumnas1);
            tablaSellos.HorizontalAlignment = Element.ALIGN_CENTER;
            //tablaSellos.LockedWidth = true;
            tablaSellos.AddCell(new Phrase("SELLO DIGITAL DEL CFDI:", new Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)));
            tablaSellos.AddCell(new Phrase(_templatePDF.selloDigitalCFDI, new Font(Font.FontFamily.HELVETICA, 4)));
            tablaSellos.AddCell(new Phrase("SELLO DIGITAL DEL SAT", new Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)));
            tablaSellos.AddCell(new Phrase(_templatePDF.selloDigitalSAT, new Font(Font.FontFamily.HELVETICA, 4)));
            tablaSellos.AddCell(new Phrase("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIFICACIÓN DIGITAL DEL SAT:", new Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)));
            tablaSellos.AddCell(new Phrase(cadenaOriginal.ToString(), new Font(Font.FontFamily.HELVETICA, 4)));

            //Agregamos el codigo QR al documento
            StringBuilder codigoQR = new StringBuilder();
            codigoQR.Append("?re" + _templatePDF.emisor.rfc); //RFC del Emisor
            codigoQR.Append("&rr" + _templatePDF.receptor.rfc); //RFC del receptor
            codigoQR.Append("&tt" + _templatePDF.total); //Total del comprobante 10 enteros y 6 decimales
            codigoQR.Append("&id" + _templatePDF.folioFiscalUUID); //UUID del comprobante

            BarcodeQRCode pdfCodigoQR = new BarcodeQRCode(codigoQR.ToString(), 1, 1, null);
            Image img = pdfCodigoQR.GetImage();
            img.SpacingAfter = 0.0f;
            img.SpacingBefore = 0.0f;
            img.BorderWidth = 1.0f;
            //img.ScalePercent(100, 78);
            //img.border

            tablaSellosQR.AddCell(tablaSellos);
            tablaSellosQR.AddCell(img);

            _documento.Add(tablaSellosQR);
        }

        #endregion

    }

    #region Extensión de la clase pdfPageEvenHelper
    public class ITextEvents : PdfPageEventHelper
    {

        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;


        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion


        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException)
            { }
            catch (System.IO.IOException)
            { }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);

            //iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            //iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            //Phrase p1Header = new Phrase("Sample Header Here", baseFontNormal);

            ////Create PdfTable object
            //PdfPTable pdfTab = new PdfPTable(3);

            ////We will have to create separate cells to include image logo and 2 separate strings
            ////Row 1
            //PdfPCell pdfCell1 = new PdfPCell();
            //PdfPCell pdfCell2 = new PdfPCell(p1Header);
            //PdfPCell pdfCell3 = new PdfPCell();
            String text = "Página " + writer.PageNumber + " de ";


            ////Add paging to header
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 12);
            //    cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
            //    cb.ShowText(text);
            //    cb.EndText();
            //    float len = bf.GetWidthPoint(text, 12);
            //    //Adds "12" in Page 1 of 12
            //    cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
            //}

            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(document.PageSize.GetRight(70), document.PageSize.GetBottom(30));
                //cb.MoveText(500,30);
                //cb.ShowText("Este comprobante es una representación impresa de un CFDI");
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 9);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(70) + len, document.PageSize.GetBottom(30));

                float[] anchoColumasTablaTotales = { 600f };
                PdfPTable tabla = new PdfPTable(anchoColumasTablaTotales);
                tabla.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla.SetTotalWidth(anchoColumasTablaTotales);
                tabla.HorizontalAlignment = Element.ALIGN_CENTER;
                tabla.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tabla.LockedWidth = true;
                tabla.AddCell(new Phrase("Este documento es una representación impresa de un CFDI 3.3", new Font(Font.FontFamily.HELVETICA, 10)));
                tabla.AddCell(new Phrase("SOFTWARE Y MAS ! WWW.CYBERCHOAPAS.COM", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD)));
                tabla.WriteSelectedRows(0, -1, 5, document.PageSize.GetBottom(40), writer.DirectContent);

            }



            ////Row 2
            //PdfPCell pdfCell4 = new PdfPCell(new Phrase("Sub Header Description", baseFontNormal));
            ////Row 3


            //PdfPCell pdfCell5 = new PdfPCell(new Phrase("Date:" + PrintTime.ToShortDateString(), baseFontBig));
            //PdfPCell pdfCell6 = new PdfPCell();
            //PdfPCell pdfCell7 = new PdfPCell(new Phrase("TIME:" + string.Format("{0:t}", DateTime.Now), baseFontBig));


            ////set the alignment of all three cells and set border to 0
            //pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER;


            //pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
            //pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            //pdfCell4.VerticalAlignment = Element.ALIGN_TOP;
            //pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
            //pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
            //pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE;


            //pdfCell4.Colspan = 3;



            //pdfCell1.Border = 0;
            //pdfCell2.Border = 0;
            //pdfCell3.Border = 0;
            //pdfCell4.Border = 0;
            //pdfCell5.Border = 0;
            //pdfCell6.Border = 0;
            //pdfCell7.Border = 0;


            ////add all three cells into PdfTable
            //pdfTab.AddCell(pdfCell1);
            //pdfTab.AddCell(pdfCell2);
            //pdfTab.AddCell(pdfCell3);
            //pdfTab.AddCell(pdfCell4);
            //pdfTab.AddCell(pdfCell5);
            //pdfTab.AddCell(pdfCell6);
            //pdfTab.AddCell(pdfCell7);

            //pdfTab.TotalWidth = document.PageSize.Width - 80f;
            //pdfTab.WidthPercentage = 70;
            ////pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;


            ////call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            ////first param is start row. -1 indicates there is no end row and all the rows to be included to write
            ////Third and fourth param is x and y position to start writing
            //pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            ////set pdfContent value

            ////Move the pointer and draw line to separate header section from rest of page
            //cb.MoveTo(40, document.PageSize.Height - 100);
            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
            //cb.Stroke();

            //Move the pointer and draw line to separate footer section from rest of page
            //cb.MoveTo(40, document.PageSize.GetBottom(50));
            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            //cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            //headerTemplate.BeginText();
            //headerTemplate.SetFontAndSize(bf, 12);
            //headerTemplate.SetTextMatrix(0, 0);
            //headerTemplate.ShowText((writer.PageNumber - 1).ToString());
            //headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 9);
            //footerTemplate.MoveText(550,30);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();
        }
    }
    #endregion

    public sealed class Numalet
    {
        private const int UNI = 0, DIECI = 1, DECENA = 2, CENTENA = 3;
        private static string[,] _matriz = new string[CENTENA + 1, 10]
            {
                {null," uno", " dos", " tres", " cuatro", " cinco", " seis", " siete", " ocho", " nueve"},
                {" diez"," once"," doce"," trece"," catorce"," quince"," dieciseis"," diecisiete"," dieciocho"," diecinueve"},
                {null,null,null," treinta"," cuarenta"," cincuenta"," sesenta"," setenta"," ochenta"," noventa"},
                {null,null,null,null,null," quinientos",null," setecientos",null," novecientos"}
            };

        #region Miembros estáticos

        private const Char sub = (Char)26;
        //Cambiar acá si se quiere otro comportamiento en los métodos de clase
        public const String SeparadorDecimalSalidaDefault = "con";
        public const String MascaraSalidaDecimalDefault = "00'/100.-'";
        public const Int32 DecimalesDefault = 2;
        public const Boolean LetraCapitalDefault = false;
        public const Boolean ConvertirDecimalesDefault = false;
        public const Boolean ApocoparUnoParteEnteraDefault = false;
        public const Boolean ApocoparUnoParteDecimalDefault = false;

        #endregion

        #region Propiedades de instancia

        private Int32 _decimales = DecimalesDefault;
        private CultureInfo _cultureInfo = CultureInfo.CurrentCulture;
        private String _separadorDecimalSalida = SeparadorDecimalSalidaDefault;
        private Int32 _posiciones = DecimalesDefault;
        private String _mascaraSalidaDecimal, _mascaraSalidaDecimalInterna = MascaraSalidaDecimalDefault;
        private Boolean _esMascaraNumerica = true;
        private Boolean _letraCapital = LetraCapitalDefault;
        private Boolean _convertirDecimales = ConvertirDecimalesDefault;
        private Boolean _apocoparUnoParteEntera = false;
        private Boolean _apocoparUnoParteDecimal;

        /// <summary>
        /// Indica la cantidad de decimales que se pasarán a entero para la conversión
        /// </summary>
        /// <remarks>Esta propiedad cambia al cambiar MascaraDecimal por un valor que empieze con '0'</remarks>
        public Int32 Decimales
        {
            get { return _decimales; }
            set
            {
                if (value > 10) throw new ArgumentException(value.ToString() + " excede el número máximo de decimales admitidos, solo se admiten hasta 10.");
                _decimales = value;
            }
        }

        /// <summary>
        /// Objeto CultureInfo utilizado para convertir las cadenas de entrada en números
        /// </summary>
        public CultureInfo CultureInfo
        {
            get { return _cultureInfo; }
            set { _cultureInfo = value; }
        }

        /// <summary>
        /// Indica la cadena a intercalar entre la parte entera y la decimal del número
        /// </summary>
        public String SeparadorDecimalSalida
        {
            get { return _separadorDecimalSalida; }
            set
            {
                _separadorDecimalSalida = value;
                //Si el separador decimal es compuesto, infiero que estoy cuantificando algo,
                //por lo que apocopo el "uno" convirtiéndolo en "un"
                if (value.Trim().IndexOf(" ") > 0)
                    _apocoparUnoParteEntera = true;
                else _apocoparUnoParteEntera = false;
            }
        }

        /// <summary>
        /// Indica el formato que se le dara a la parte decimal del número
        /// </summary>
        public String MascaraSalidaDecimal
        {
            get
            {
                if (!String.IsNullOrEmpty(_mascaraSalidaDecimal))
                    return _mascaraSalidaDecimal;
                else return "";
            }
            set
            {
                //determino la cantidad de cifras a redondear a partir de la cantidad de '0' o '#' 
                //que haya al principio de la cadena, y también si es una máscara numérica
                int i = 0;
                while (i < value.Length
                    && (value[i] == '0')
                        | value[i] == '#')
                    i++;
                _posiciones = i;
                if (i > 0)
                {
                    _decimales = i;
                    _esMascaraNumerica = true;
                }
                else _esMascaraNumerica = false;
                _mascaraSalidaDecimal = value;
                if (_esMascaraNumerica)
                    _mascaraSalidaDecimalInterna = value.Substring(0, _posiciones) + "'"
                        + value.Substring(_posiciones)
                        .Replace("''", sub.ToString())
                        .Replace("'", String.Empty)
                        .Replace(sub.ToString(), "'") + "'";
                else
                    _mascaraSalidaDecimalInterna = value
                        .Replace("''", sub.ToString())
                        .Replace("'", String.Empty)
                        .Replace(sub.ToString(), "'");
            }
        }

        /// <summary>
        /// Indica si la primera letra del resultado debe estár en mayúscula
        /// </summary>
        public Boolean LetraCapital
        {
            get { return _letraCapital; }
            set { _letraCapital = value; }
        }

        /// <summary>
        /// Indica si se deben convertir los decimales a su expresión nominal
        /// </summary>
        public Boolean ConvertirDecimales
        {
            get { return _convertirDecimales; }
            set
            {
                _convertirDecimales = value;
                _apocoparUnoParteDecimal = value;
                if (value)
                {// Si la máscara es la default, la borro
                    if (_mascaraSalidaDecimal == MascaraSalidaDecimalDefault)
                        MascaraSalidaDecimal = "";
                }
                else if (String.IsNullOrEmpty(_mascaraSalidaDecimal))
                    //Si no hay máscara dejo la default
                    MascaraSalidaDecimal = MascaraSalidaDecimalDefault;
            }
        }

        /// <summary>
        /// Indica si de debe cambiar "uno" por "un" en las unidades.
        /// </summary>
        public Boolean ApocoparUnoParteEntera
        {
            get { return _apocoparUnoParteEntera; }
            set { _apocoparUnoParteEntera = value; }
        }

        /// <summary>
        /// Determina si se debe apococopar el "uno" en la parte decimal
        /// </summary>
        /// <remarks>El valor de esta propiedad cambia al setear ConvertirDecimales</remarks>
        public Boolean ApocoparUnoParteDecimal
        {
            get { return _apocoparUnoParteDecimal; }
            set { _apocoparUnoParteDecimal = value; }
        }

        #endregion

        #region Constructores

        public Numalet()
        {
            MascaraSalidaDecimal = MascaraSalidaDecimalDefault;
            SeparadorDecimalSalida = SeparadorDecimalSalidaDefault;
            LetraCapital = LetraCapitalDefault;
            ConvertirDecimales = _convertirDecimales;
        }

        public Numalet(Boolean ConvertirDecimales, String MascaraSalidaDecimal, String SeparadorDecimalSalida, Boolean LetraCapital)
        {
            if (!String.IsNullOrEmpty(MascaraSalidaDecimal))
                this.MascaraSalidaDecimal = MascaraSalidaDecimal;
            if (!String.IsNullOrEmpty(SeparadorDecimalSalida))
                _separadorDecimalSalida = SeparadorDecimalSalida;
            _letraCapital = LetraCapital;
            _convertirDecimales = ConvertirDecimales;
        }
        #endregion

        #region Conversores de instancia

        public String ToCustomString(Double Numero)
        { return Convertir((Decimal)Numero, _decimales, _separadorDecimalSalida, _mascaraSalidaDecimalInterna, _esMascaraNumerica, _letraCapital, _convertirDecimales, _apocoparUnoParteEntera, _apocoparUnoParteDecimal); }

        public String ToCustomString(String Numero)
        {
            Double dNumero;
            if (Double.TryParse(Numero, NumberStyles.Float, _cultureInfo, out dNumero))
                return ToCustomString(dNumero);
            else throw new ArgumentException("'" + Numero + "' no es un número válido.");
        }

        public String ToCustomString(Decimal Numero)
        { return ToString(Convert.ToDouble(Numero)); }

        public String ToCustomString(Int32 Numero)
        { return Convertir((Decimal)Numero, 0, _separadorDecimalSalida, _mascaraSalidaDecimalInterna, _esMascaraNumerica, _letraCapital, _convertirDecimales, _apocoparUnoParteEntera, false); }


        #endregion

        #region Conversores estáticos

        public static String ToString(Int32 Numero)
        {
            return Convertir((Decimal)Numero, 0, null, null, true, LetraCapitalDefault, ConvertirDecimalesDefault, ApocoparUnoParteEnteraDefault, ApocoparUnoParteDecimalDefault);
        }

        public static String ToString(Double Numero)
        { return Convertir((Decimal)Numero, DecimalesDefault, SeparadorDecimalSalidaDefault, MascaraSalidaDecimalDefault, true, LetraCapitalDefault, ConvertirDecimalesDefault, ApocoparUnoParteEnteraDefault, ApocoparUnoParteDecimalDefault); }

        public static String ToString(String Numero, CultureInfo ReferenciaCultural)
        {
            Double dNumero;
            if (Double.TryParse(Numero, NumberStyles.Float, ReferenciaCultural, out dNumero))
                return ToString(dNumero);
            else throw new ArgumentException("'" + Numero + "' no es un número válido.");
        }

        public static String ToString(String Numero)
        {
            return Numalet.ToString(Numero, CultureInfo.CurrentCulture);
        }

        public static String ToString(Decimal Numero)
        { return ToString(Convert.ToDouble(Numero)); }

        #endregion

        private static String Convertir(Decimal Numero, Int32 Decimales, String SeparadorDecimalSalida, String MascaraSalidaDecimal, Boolean EsMascaraNumerica, Boolean LetraCapital, Boolean ConvertirDecimales, Boolean ApocoparUnoParteEntera, Boolean ApocoparUnoParteDecimal)
        {
            Int64 Num;
            Int32 terna, pos, centenaTerna, decenaTerna, unidadTerna, iTerna;
            String numcad, cadTerna;
            StringBuilder Resultado = new StringBuilder();

            Num = (Int64)Math.Abs(Numero);

            if (Num >= 1000000000000 || Num < 0) throw new ArgumentException("El número '" + Numero.ToString() + "' excedió los límites del conversor: [0;1.000.000.000.000)");
            if (Num == 0)
                Resultado.Append(" cero");
            else
            {
                numcad = Num.ToString();
                iTerna = 0;
                pos = numcad.Length;

                do //Se itera por las ternas de atrás para adelante
                {
                    iTerna++;
                    cadTerna = String.Empty;
                    if (pos >= 3)
                        terna = Int32.Parse(numcad.Substring(pos - 3, 3));
                    else
                        terna = Int32.Parse(numcad.Substring(0, pos));

                    centenaTerna = (Int32)(terna / 100);
                    decenaTerna = terna - centenaTerna * 100;
                    unidadTerna = (decenaTerna - (Int32)(decenaTerna / 10) * 10);

                    if ((decenaTerna > 0) && (decenaTerna < 10))
                        cadTerna = _matriz[UNI, unidadTerna] + cadTerna;
                    else if ((decenaTerna >= 10) && (decenaTerna < 20))
                        cadTerna = cadTerna + _matriz[DIECI, decenaTerna - (Int32)(decenaTerna / 10) * 10];
                    else if (decenaTerna == 20)
                        cadTerna = cadTerna + " veinte";
                    else if ((decenaTerna > 20) && (decenaTerna < 30))
                        cadTerna = " veinti" + _matriz[UNI, unidadTerna].Substring(1, _matriz[UNI, unidadTerna].Length - 1);
                    else if ((decenaTerna >= 30) && (decenaTerna < 100))
                        if (unidadTerna != 0)
                            cadTerna = _matriz[DECENA, (Int32)(decenaTerna / 10)] + " y" + _matriz[UNI, unidadTerna] + cadTerna;
                        else
                            cadTerna += _matriz[DECENA, (Int32)(decenaTerna / 10)];

                    switch (centenaTerna)
                    {
                        case 1:
                            if (decenaTerna > 0) cadTerna = " ciento" + cadTerna;
                            else cadTerna = " cien" + cadTerna;
                            break;
                        case 5:
                        case 7:
                        case 9:
                            cadTerna = _matriz[CENTENA, (Int32)(terna / 100)] + cadTerna;
                            break;
                        default:
                            if ((Int32)(terna / 100) > 1) cadTerna = _matriz[UNI, (Int32)(terna / 100)] + "cientos" + cadTerna;
                            break;
                    }
                    //Reemplazo el 'uno' por 'un' si no es en las únidades o si se solicító apocopar
                    if ((iTerna > 1 | ApocoparUnoParteEntera) && decenaTerna == 21)
                        cadTerna = cadTerna.Replace("veintiuno", "veintiún");
                    else if ((iTerna > 1 | ApocoparUnoParteEntera) && unidadTerna == 1 && decenaTerna != 11)
                        cadTerna = cadTerna.Substring(0, cadTerna.Length - 1);
                    //Acentúo 'dieciseís', 'veintidós', 'veintitrés' y 'veintiséis'
                    else if (decenaTerna == 16) cadTerna = cadTerna.Replace("dieciseis", "dieciséis");
                    else if (decenaTerna == 22) cadTerna = cadTerna.Replace("veintidos", "veintidós");
                    else if (decenaTerna == 23) cadTerna = cadTerna.Replace("veintitres", "veintitrés");
                    else if (decenaTerna == 26) cadTerna = cadTerna.Replace("veintiseis", "veintiséis");
                    //Reemplazo 'uno' por 'un' si no es en las únidades o si se solicító apocopar (si _apocoparUnoParteEntera es verdadero) 

                    switch (iTerna)
                    {
                        case 3:
                            if (Num < 2000000) cadTerna += " millón";
                            else cadTerna += " millones";
                            break;
                        case 2:
                        case 4:
                            if (terna > 0) cadTerna += " mil";
                            break;
                    }
                    Resultado.Insert(0, cadTerna);
                    pos = pos - 3;
                } while (pos > 0);
            }
            //Se agregan los decimales si corresponde
            if (Decimales > 0)
            {
                Resultado.Append(" " + SeparadorDecimalSalida + " ");
                Int32 EnteroDecimal = (Int32)Math.Round((Double)(Numero - (Int64)Numero) * Math.Pow(10, Decimales), 0);
                if (ConvertirDecimales)
                {
                    Boolean esMascaraDecimalDefault = MascaraSalidaDecimal == MascaraSalidaDecimalDefault;
                    Resultado.Append(Convertir((Decimal)EnteroDecimal, 0, null, null, EsMascaraNumerica, false, false, (ApocoparUnoParteDecimal && !EsMascaraNumerica/*&& !esMascaraDecimalDefault*/), false) + " "
                        + (EsMascaraNumerica ? "" : MascaraSalidaDecimal));
                }
                else
                    if (EsMascaraNumerica) Resultado.Append(EnteroDecimal.ToString(MascaraSalidaDecimal));
                else Resultado.Append(EnteroDecimal.ToString() + " " + MascaraSalidaDecimal);
            }
            //Se pone la primer letra en mayúscula si corresponde y se retorna el resultado
            if (LetraCapital)
                return Resultado[1].ToString().ToUpper() + Resultado.ToString(2, Resultado.Length - 2);
            else
                return Resultado.ToString().Substring(1);
        }
    }
}
