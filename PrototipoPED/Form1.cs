﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototipoPED
{
    public partial class Interfaz : Form
    {
        bool btnBLPulsado = true, btnUPulsado = false;
        

        public Interfaz()
        {
            InitializeComponent();
            AbrirFormulario(new FrmAuxiliar());
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            if (btnUPulsado)
            {
                pnlUsuario.Visible = false;
            }
            else
            {
                pnlUsuario.BringToFront();
                pnlUsuario.Visible = true;
            }
            btnUPulsado = !btnUPulsado;
        }

        //Dimensiones del pnlForm = 838, 371

        private void btnBarraLateral_Click(object sender, EventArgs e)
        {
            BarraLateral(ref btnBLPulsado);
        }


        private Form FormAbierto = null;

        private void btnRegistrarPacientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FmrIngresoDatosPaciente());
        }

        private void BarraLateral(ref bool btnBlPulsado)
        {
            if (btnBLPulsado)
            {
                btnBarraLateral.IconChar = FontAwesome.Sharp.IconChar.Ellipsis;
                pnlBarraLateral.Visible = false;
            }
            else
            {
                btnBarraLateral.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                pnlBarraLateral.Visible = true;
            }
            btnBLPulsado = !btnBLPulsado;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); AbrirFormulario(new FmrIngresoDatosPaciente());
        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
        }

        private void AbrirFormulario(Form FormHijo)
        {
            if(FormAbierto != null)
            {
                FormAbierto.Close();
            }
            FormAbierto = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.FormBorderStyle = FormBorderStyle.None;
            FormHijo.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(FormHijo);
            pnlForm.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();

            BarraLateral(ref btnBLPulsado);
        }
    }
}
