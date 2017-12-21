using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MOB_EDITOR;

namespace MOB_EDITOR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.ReadNpc();
                this.ReadItemList();
            }
            catch
            {
                MessageBox.Show("Erro ao abrir o aplicativo!");
            }
        }

        private void ReadNpc()
        {
            try
            {
                Editor.ReadNpc();
                foreach (STRUCT_MOB MOB in Editor.NPCs)
                {
                    lbNpc.Items.Add(MOB.name);

                }
            }
            catch
            {
                MessageBox.Show("Erro ao adicionar ler os NPC`s");
            }
        }

        private void ReadItemList()
        {
            try
            {
                Editor.ReadItemList();
            }
            catch
            {
                MessageBox.Show("Erro ao ler itemlist.bin");
            }
        }

        public static int Sizeof<T>()
        {
            return System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
        }

        private void lbNpc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = lbNpc.SelectedIndex;

            // Informações do MOB
            txtNome.Text = Editor.NPCs[index].name.ToString();
            txtRace.Text = Editor.NPCs[index].Clan.ToString();
            txtMerchant.Text = Editor.NPCs[index].Merchant.ToString();
            txtClasse.Text = Editor.NPCs[index].Class.ToString();
            txtMoney.Text = Editor.NPCs[index].Coin.ToString();
            txtExp.Text = Editor.NPCs[index].Exp.ToString();
            txtPosX.Text = Editor.NPCs[index].SPX.ToString();
            txtPosY.Text = Editor.NPCs[index].SPY.ToString();
            txtSkill.Text = Editor.NPCs[index].SkillBar[0].ToString() + " " + Editor.NPCs[index].SkillBar[1].ToString() + " " + Editor.NPCs[index].SkillBar[2].ToString() + " " + Editor.NPCs[index].SkillBar[3].ToString();
            txtLearn.Text = Editor.NPCs[index].LearnedSkill.ToString();
            txtRegenHP.Text = Editor.NPCs[index].RegenHP.ToString();
            txtRegenMP.Text = Editor.NPCs[index].RegenMP.ToString();
            txtResist.Text = Editor.NPCs[index].Resist[0].ToString() + " " + Editor.NPCs[index].Resist[1].ToString() + " " + Editor.NPCs[index].Resist[2].ToString() + " " + Editor.NPCs[index].Resist[3].ToString();
            txtDirect.Text = Editor.NPCs[index].BaseScore.Speed.ToString();
            txtBonus.Text = Editor.NPCs[index].ScoreBonus.ToString();

            // informações do equipe do mob
            foreach (Control gp in Equips.Controls)
            {
                if (gp is TextBox)
                {
                    gp.Text = Editor.NPCs[index].Equip[gp.TabIndex].sIndex.ToString() + " " +
                    Editor.NPCs[index].Equip[gp.TabIndex].sEffect[0].cEfeito.ToString() + " " +
                    Editor.NPCs[index].Equip[gp.TabIndex].sEffect[0].cValue.ToString() + " " +
                    Editor.NPCs[index].Equip[gp.TabIndex].sEffect[1].cEfeito.ToString() + " " +
                    Editor.NPCs[index].Equip[gp.TabIndex].sEffect[1].cValue.ToString() + " " +
                    Editor.NPCs[index].Equip[gp.TabIndex].sEffect[2].cEfeito.ToString() + " " +
                    Editor.NPCs[index].Equip[gp.TabIndex].sEffect[2].cValue.ToString();
                }
            }

            // Score do MOB
            txtLevel.Text = Editor.NPCs[index].BaseScore.Level.ToString();
            txtDef.Text = Editor.NPCs[index].BaseScore.Defesa.ToString();
            txtDano.Text = Editor.NPCs[index].BaseScore.Ataque.ToString();
            txtStr.Text = Editor.NPCs[index].BaseScore.Str.ToString();
            txtInt.Text = Editor.NPCs[index].BaseScore.Int.ToString();
            txtDex.Text = Editor.NPCs[index].BaseScore.Dex.ToString();
            txtCon.Text = Editor.NPCs[index].BaseScore.Con.ToString();
            txtHP.Text = Editor.NPCs[index].BaseScore.HP.ToString();
            txtMaxHP.Text = Editor.NPCs[index].BaseScore.MaxHP.ToString();
            txtMP.Text = Editor.NPCs[index].BaseScore.MP.ToString();
            txtMaxMP.Text = Editor.NPCs[index].BaseScore.MaxMP.ToString();
            txtNear.Text = Editor.NPCs[index].BaseScore.Special[0].ToString();
            txtMotion1.Text = Editor.NPCs[index].BaseScore.Special[1].ToString();
            txtFar.Text = Editor.NPCs[index].BaseScore.Special[2].ToString();
            txtMotion2.Text = Editor.NPCs[index].BaseScore.Special[3].ToString();

            //Informações do inventario do MOB
            foreach (Control tb2 in Inventario.Controls)
            {
                if (tb2 is TextBox)
                {
                    if (tb2.Enabled == true)
                    {
                        tb2.Text = Editor.NPCs[index].Carry[tb2.TabIndex].sIndex.ToString() + " " +
                        Editor.NPCs[index].Carry[tb2.TabIndex].sEffect[0].cEfeito.ToString() + " " +
                        Editor.NPCs[index].Carry[tb2.TabIndex].sEffect[0].cValue.ToString() + " " +
                        Editor.NPCs[index].Carry[tb2.TabIndex].sEffect[1].cEfeito.ToString() + " " +
                        Editor.NPCs[index].Carry[tb2.TabIndex].sEffect[1].cValue.ToString() + " " +
                        Editor.NPCs[index].Carry[tb2.TabIndex].sEffect[2].cEfeito.ToString() + " " +
                        Editor.NPCs[index].Carry[tb2.TabIndex].sEffect[2].cValue.ToString();
                    }

                    if (tb2.Enabled == false)
                    {
                        int Item = Editor.NPCs[index].Carry[tb2.TabIndex].sIndex;
                        tb2.Text = Editor.ItemList.item[Item].Name.ToString();
                    }
                }
            }
        }

        // Botão de salvar
        private void button1_Click(object sender, EventArgs e)
        {
            STRUCT_MOB npc = Editor.NPCs[lbNpc.SelectedIndex];

//             Salvar informações do MOB
            npc.name = txtNome.Text.ToString();
            npc.Coin = Convert.ToInt32(txtMoney.Text.ToString());
            npc.Clan = Convert.ToByte(txtRace.Text.ToString());
            npc.Merchant = Convert.ToByte(txtMerchant.Text.ToString());
            npc.Class = Convert.ToByte(txtClasse.Text.ToString());
            npc.Coin = Convert.ToInt32(txtMoney.Text.ToString());
            npc.Exp = Convert.ToInt64(txtExp.Text.ToString());
            npc.SPX = Convert.ToInt16(txtPosX.Text.ToString());
            npc.SPY = Convert.ToInt16(txtPosY.Text.ToString());
            string texto = txtSkill.Text;
            string[] split = texto.Split(' ');
            npc.SkillBar[0] = Convert.ToByte(split[0]);
            npc.SkillBar[1] = Convert.ToByte(split[1]);
            npc.SkillBar[2] = Convert.ToByte(split[2]);
            npc.SkillBar[3] = Convert.ToByte(split[3]);
            npc.LearnedSkill = Convert.ToUInt64(txtLearn.Text.ToString());
            npc.RegenHP = Convert.ToInt16(txtRegenHP.Text.ToString());
            npc.RegenMP = Convert.ToInt16(txtRegenMP.Text.ToString());
            string texto2 = txtResist.Text;
            string[] split2 = texto2.Split(' ');
            npc.Resist[0] = Convert.ToByte(split2[0]);
            npc.Resist[1] = Convert.ToByte(split2[1]);
            npc.Resist[2] = Convert.ToByte(split2[2]);
            npc.Resist[3] = Convert.ToByte(split2[3]);
            npc.BaseScore.Speed = Convert.ToByte(txtDirect.Text.ToString());
            npc.ScoreBonus = Convert.ToInt16(txtBonus.Text.ToString());


            // Salvar Informações do Score do MOB
            npc.BaseScore.Level = Convert.ToInt32(txtLevel.Text.ToString());
            npc.BaseScore.Defesa = Convert.ToInt32(txtDef.Text.ToString());
            npc.BaseScore.Ataque = Convert.ToInt32(txtDano.Text.ToString());
            npc.BaseScore.Str = Convert.ToInt16(txtStr.Text.ToString());
            npc.BaseScore.Int = Convert.ToInt16(txtInt.Text.ToString());
            npc.BaseScore.Dex = Convert.ToInt16(txtDex.Text.ToString());
            npc.BaseScore.Con = Convert.ToInt16(txtCon.Text.ToString());
            npc.BaseScore.HP = Convert.ToInt32(txtHP.Text.ToString());
            npc.BaseScore.MaxHP = Convert.ToInt32(txtMaxHP.Text.ToString());
            npc.BaseScore.MP = Convert.ToInt32(txtMP.Text.ToString());
            npc.BaseScore.MaxMP = Convert.ToInt32(txtMaxMP.Text.ToString());
            npc.BaseScore.Special[0] = Convert.ToInt16(txtNear.Text.ToString());
            npc.BaseScore.Special[1] = Convert.ToInt16(txtMotion1.Text.ToString());
            npc.BaseScore.Special[2] = Convert.ToInt16(txtFar.Text.ToString());
            npc.BaseScore.Special[3] = Convert.ToInt16(txtMotion2.Text.ToString());


            // Salvar informações do Equipamento do MOB
            foreach (Control gp in Equips.Controls)
            {
                if (gp is TextBox)
                {
                    npc.Equip[gp.TabIndex].sIndex = Convert.ToInt16(gp.Text.Split(' ')[0]);
                    npc.Equip[gp.TabIndex].sEffect[0].cEfeito = Convert.ToByte(gp.Text.Split(' ')[1]);
                    npc.Equip[gp.TabIndex].sEffect[0].cValue = Convert.ToByte(gp.Text.Split(' ')[2]);
                    npc.Equip[gp.TabIndex].sEffect[1].cEfeito = Convert.ToByte(gp.Text.Split(' ')[3]);
                    npc.Equip[gp.TabIndex].sEffect[1].cValue = Convert.ToByte(gp.Text.Split(' ')[4]);
                    npc.Equip[gp.TabIndex].sEffect[2].cEfeito = Convert.ToByte(gp.Text.Split(' ')[5]);
                    npc.Equip[gp.TabIndex].sEffect[2].cValue = Convert.ToByte(gp.Text.Split(' ')[6]);
                }
            }

            foreach (Control textbox in Inventario.Controls)
            {
                if(textbox is TextBox)
                {
                    if (textbox.Enabled == true)
                    {
                        npc.Carry[textbox.TabIndex].sIndex = Convert.ToInt16(textbox.Text.Split(' ')[0]);
                        npc.Carry[textbox.TabIndex].sEffect[0].cEfeito = Convert.ToByte(textbox.Text.Split(' ')[1]);
                        npc.Carry[textbox.TabIndex].sEffect[0].cValue = Convert.ToByte(textbox.Text.Split(' ')[2]);
                        npc.Carry[textbox.TabIndex].sEffect[1].cEfeito = Convert.ToByte(textbox.Text.Split(' ')[3]);
                        npc.Carry[textbox.TabIndex].sEffect[1].cValue = Convert.ToByte(textbox.Text.Split(' ')[4]);
                        npc.Carry[textbox.TabIndex].sEffect[2].cEfeito = Convert.ToByte(textbox.Text.Split(' ')[5]);
                        npc.Carry[textbox.TabIndex].sEffect[2].cValue = Convert.ToByte(textbox.Text.Split(' ')[6]);
                    }
                }
            }

            MessageBox.Show(string.Format("O mob {0} foi salvo com sucesso!", npc.name));

            Editor.NPCs[lbNpc.SelectedIndex] = npc;
            Editor.SaveNPC(npc);
                
        }

        // Responsavel pela mudança de nome do textbox
        private void textchange(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox == null)
                return;

            var itemName = Inventario.Controls.OfType<TextBox>().First(c => c.TabIndex == textBox.TabIndex && c.Enabled == false);

            Editor.NPCs[lbNpc.SelectedIndex].Carry[textBox.TabIndex].sIndex = Convert.ToInt16(textBox.Text.Split(' ')[0]); // seila se pode fazer isso dai se vira

            itemName.Text = Editor.ItemList.item[Editor.NPCs[lbNpc.SelectedIndex].Carry[textBox.TabIndex].sIndex].Name;
        }
    }
}
