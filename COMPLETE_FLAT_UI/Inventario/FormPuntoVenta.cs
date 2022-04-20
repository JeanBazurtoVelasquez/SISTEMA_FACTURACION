using CapaNegocio.Models.Inventario;
using CapaNegocio.Repository.Inventario;
using CapaNegocio.ViewModels.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class FormPuntoVenta : Form
    {
        ProductoVenta _producto;
        ProductoRepository _productoRepo;
        int _establecimientoid = 1; //Cambiar por el establecimiento del usuario
        public FormPuntoVenta()
        {
            InitializeComponent();
            _productoRepo = new ProductoRepository();
        }

        private async void txtBuscaProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                bool encontrado = false;
                if (!txtBuscaProducto.Text.Trim().Equals("")) {
                    Producto producto = await _productoRepo.GetByCodBar(txtBuscaProducto.Text);
                    if (producto != null) {
                        _producto = await _productoRepo.GetProductoVenta(producto.Id, _establecimientoid);
                        if (_producto != null)
                        {
                            txtBuscaProducto.Text = _producto.producto.Codigo;
                            txtProducto.Text = _producto.producto.Nombre;
                            LlenaComboUnidad(_producto.listaPrecios);
                            encontrado = true;
                        }
                    }
                }
                if (!encontrado)
                {
                    FormListaProductos frm = new FormListaProductos(true, txtBuscaProducto.Text.Trim());
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        _producto = await _productoRepo.GetProductoVenta(frm._idproducto, _establecimientoid);
                        if (_producto != null)
                        {
                            txtBuscaProducto.Text = _producto.producto.Codigo;
                            txtProducto.Text = _producto.producto.Nombre;
                            LlenaComboUnidad(_producto.listaPrecios);
                        }
                    }
                }
            }
        }

        private void LlenaComboUnidad(List<ProductoPrecio> lista) {
            cmbUnidad.DataSource = null;
            List<object> items = new List<object>();
            foreach (var item in lista)
                items.Add(new { Texto = item.UnidadDescripcion, Value = item.Id });
            cmbUnidad.DataSource = items;
            cmbUnidad.DisplayMember = "Texto";
            cmbUnidad.ValueMember = "Value";
            cmbUnidad.SelectedIndex = 0; //Cambiar por la unidad  fijada como favorita
            cmbUnidad_SelectionChangeCommitted(cmbUnidad, null);
        }
        private void LlenaComboPrecio(ProductoPrecio precios)
        {
            cmbPrecio.DataSource = null;
            List<object> items = new List<object>();
            if (precios.Precio1 > 0)
                items.Add(new { Texto = "Precio 1", Value = precios.Precio1 });
            if (precios.Precio2 > 0)
                items.Add(new { Texto = "Precio 2", Value = precios.Precio2 });
            if (precios.Precio3 > 0)
                items.Add(new { Texto = "Precio 3", Value = precios.Precio3 });
            if (precios.Precio4 > 0)
                items.Add(new { Texto = "Precio 4", Value = precios.Precio4 });
            if (precios.Precio5 > 0)
                items.Add(new { Texto = "Precio 5", Value = precios.Precio5 });

            cmbPrecio.DataSource = items;
            cmbPrecio.DisplayMember = "Texto";
            cmbPrecio.ValueMember = "Value";
            cmbPrecio.SelectedIndex = 0;
            cmbPrecio_SelectionChangeCommitted(cmbUnidad, null);
        }

        private void cmbUnidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_producto != null) {
                var id = (int)cmbUnidad.SelectedValue;
                LlenaComboPrecio(_producto.listaPrecios.Find(x => x.Id == id));
            }
        }

        private void cmbPrecio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtPrecio.Text = Double.Parse(cmbPrecio.SelectedValue.ToString()).ToString("0.00");
            txtCantidad.SelectAll();
            txtCantidad.Focus();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!txtCantidad.Text.Trim().Equals("") && _producto != null && e.KeyCode == Keys.Enter)
                {
                    double cant = Double.Parse(txtCantidad.Text.Trim());
                    if (cant <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad mayor a 0");
                        txtCantidad.SelectAll();
                        txtCantidad.Focus();
                    }
                    else
                    {
                        dgvProductos.Rows.Add(1);
                        int pos = dgvProductos.RowCount - 1;
                        double precio = Double.Parse(cmbPrecio.SelectedValue.ToString());
                        dgvProductos.Rows[pos].Cells[0].Value = _producto.producto.Codigo;
                        dgvProductos.Rows[pos].Cells[0].Tag = _producto.producto.Id;
                        dgvProductos.Rows[pos].Cells[1].Value = _producto.producto.Nombre;
                        dgvProductos.Rows[pos].Cells[2].Value = precio;
                        dgvProductos.Rows[pos].Cells[3].Value = cant;
                        dgvProductos.Rows[pos].Cells[4].Value = (precio * cant).ToString("0.00");
                        dgvProductos.Rows[pos].Cells[5].Value = _producto.producto.Grabaiva;
                        dgvProductos.Rows[pos].Cells[6].Value = cmbUnidad.Text;
                        
                        LimpiaProducto();
                    }
                }
            }catch(Exception ex)
            {
                
            }
        }

        private void LimpiaProducto()
        {
            _producto = null;
            cmbUnidad.DataSource = null;
            cmbPrecio.DataSource = null;
            txtBuscaProducto.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtBuscaProducto.Focus();
        }
    }
}
