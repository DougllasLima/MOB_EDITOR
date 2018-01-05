using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MOB_EDITOR.Properties;

namespace MOB_EDITOR
{
    public partial class Localizador : Form
    {
        Form1 Form1;


        public Localizador(Form1 fmr)
        {
            InitializeComponent();
            Form1 = fmr;
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                var Editor = new Editor();
                int encontrados = Editor.LocalizarItens(Convert.ToInt32(txtLocaliza.Text));
                int itemID = Convert.ToInt32(txtLocaliza.Text);
                MessageBox.Show(string.Format("Foram encontrados {0} {1} dos MOB's", encontrados, Editor.ItemList.item[itemID].Name));

                lbMobsLocalizados.Items.Clear();
                foreach (STRUCT_MOB mob in Editor.MOBsLocalizados)
                {
                    lbMobsLocalizados.Items.Add(mob.name);
                }

                if (MessageBox.Show("Deseja mover os mobs para aba principal para melhor visualização?", "Aviso!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Form1.lbNpc.Items.Clear();
                    foreach (STRUCT_MOB mob in Editor.MOBsLocalizados)
                    {
                        Form1.lbNpc.Items.Add(mob.name);
                    }

                    Editor.ReadNPCNovo(Editor.MOBsLocalizados);

                    this.Close();
                }
                else
                    return;             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Programa do Dougras xD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Editor.MOBsLocalizados.Clear();
            }

        }
    }
}
