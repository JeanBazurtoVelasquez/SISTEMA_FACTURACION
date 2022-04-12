using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace COMPLETE_FLAT_UI.Inventario
{
    public partial class FormRegCompra : Form
    {
        public FormRegCompra()
        {
            InitializeComponent();
        }

        private void btnCargarXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ".";
            file.Filter = "Todos los archivos (*. *) | *. *";
            file.ShowDialog();
            if (file.FileName != string.Empty)
            {
                try
                {
                    XElement XTemp = XElement.Load(file.FileName);
                    var queryCDATAXML = from element in XTemp.DescendantNodes()
                                        where element.NodeType == System.Xml.XmlNodeType.CDATA
                                        select element.Parent.Value.Trim();
                    string BodyHtml = queryCDATAXML.ToList<string>()[0].ToString();
                    XDocument xmlFactura = XDocument.Parse(BodyHtml);

                    IEnumerable<XElement> detalle = xmlFactura.Root.Elements("detalles").Elements("detalle");
                    double valorImpuesto;
                    foreach (var producto in detalle)
                    {
                        valorImpuesto = 0.00;
                        IEnumerable<XElement> impuestos = producto.Elements("impuestos").Elements("impuesto");
                        foreach (var impuesto in impuestos)
                        {
                            MessageBox.Show(impuesto.Element("valor").Value);
                            valorImpuesto += double.Parse(impuesto.Element("valor").Value, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        tblItems.Rows.Add(1);
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[0].Value = producto.Element("cantidad").Value;
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[1].Value = producto.Element("codigoPrincipal").Value;
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[2].Value = producto.Element("descripcion").Value;
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[3].Value = "";
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[4].Value = "";
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[5].Value = producto.Element("precioUnitario").Value;
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[6].Value = producto.Element("descuento").Value;
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[7].Value = valorImpuesto;
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[8].Value = producto.Element("precioTotalSinImpuesto").Value;
                        tblItems.Rows[tblItems.Rows.Count - 1].Cells[9].Value = double.Parse(producto.Element("precioTotalSinImpuesto").Value, System.Globalization.CultureInfo.InvariantCulture) + valorImpuesto;
                    }

                    
                }
                finally
                {
                    if (file.FileName == string.Empty)
                        MessageBox.Show("No se pudo cargar el archivo");
                }
            }
        }
    }
}
