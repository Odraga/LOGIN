using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace LOGIN
{
    public partial class Form2 : Form
    {
        SqlConnection conexion = new SqlConnection("server = S4MUPC;database=MiEmpresa; integrated security=true");

        public Form2()
        {
            InitializeComponent();
            
            
        }
        //consultar(); arriba
        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    

        private void v(object sender, PaintEventArgs e)
        {

        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {  //este es el foco enter para poder ocultar lo que dice por defecto el textbox
            if(txtNombre.Text == "NOMBRE")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {   // ESTE ES EL FOCO LEAVE para cuando salga el mouse del cuadro vuelva lo que dice por defecto el txtbox
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm1= new Form1();
            

            DialogResult dialog = MessageBox.Show("Seguro que quieres cerrar sesion?",
                "AVISO", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                this.Hide();
                frm1.Show();
            }
            else if (dialog == DialogResult.No)
            {
                
            }






            //MessageBox.Show("SEGURO QUE QUIERES CERRAR SECCION?","alerta", MessageBoxButtons.OKCancel);
         
            
        }

        //private void actualizar(string consulta) 
        //{
        //    SqlCommand comando = new SqlCommand("select * from regusuarios", conexion);
        //    SqlDataAdapter adaptador = new SqlDataAdapter();
        //    adaptador.SelectCommand = comando;
        //    DataTable tabla = new DataTable();
        //    adaptador.Fill(tabla);
        //    dataGridView1.DataSource = tabla;
        //}

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "APELLIDO")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.DimGray;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "")
            {
                txtApellido.Text = "APELLIDO";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtEdad_Enter(object sender, EventArgs e)
        {
            if (txtEdad.Text == "EDAD")
            {
                txtEdad.Text = "";
                txtEdad.ForeColor = Color.DimGray;
            }
        }

        private void txtEdad_Leave(object sender, EventArgs e)
        {
            if (txtEdad.Text == "")
            {
                txtEdad.Text = "EDAD";
                txtEdad.ForeColor = Color.DimGray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "TELEFONO")
            {
                txtTelefono.Text = "";
                txtTelefono.ForeColor = Color.DimGray;
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "TELEFONO";
                txtTelefono.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            
            SqlCommand comando = new SqlCommand("select * from regusuarios", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;

        }
        //private void consultar() {
        //    SqlCommand comando = new SqlCommand("select * from regusuarios", conexion);
        //    SqlDataAdapter adaptador = new SqlDataAdapter();
        //    adaptador.SelectCommand = comando;
        //    DataTable tabla = new DataTable();
        //    adaptador.Fill(tabla);
        //    dataGridView1.DataSource = tabla;
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            
            string cadena = "insert into Regusuarios ([id] ,[Nombre] ,[Apellido] ,[Edad] ,[Telefono])" +
                " values ('','" + txtNombre.Text + "','" + txtApellido.Text + "','" + txtEdad.Text + "','" + txtTelefono.Text + "')";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("La persona:" + txtNombre.Text + " se ha agregado correctamente ");

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";

            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE";
                txtNombre.ForeColor = Color.DimGray;
            }

            if (txtApellido.Text == "")
            {
                txtApellido.Text = "APELLIDO";
                txtNombre.ForeColor = Color.DimGray;
            }

            if (txtEdad.Text == "")
            {
                txtEdad.Text = "EDAD";
                txtEdad.ForeColor = Color.DimGray;
            }

            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "TELEFONO";
                txtTelefono.ForeColor = Color.DimGray;
            }

            SqlCommand actualiza = new SqlCommand("select * from regusuarios", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = actualiza;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;





            conexion.Close();
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            conexion.Open();
            // FILTRANDO LOS DATOS POR NOMBRE
            SqlCommand cmmd = conexion.CreateCommand();
            cmmd.CommandType = CommandType.Text;
            cmmd.CommandText = "SELECT * FROM Regusuarios WHERE Nombre Like('" + txtBuscar.Text + "%')";
            cmmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmmd);

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            conexion.Close();
        }
    }
    }
