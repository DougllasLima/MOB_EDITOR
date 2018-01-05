using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

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
                foreach (STRUCT_MOB MOB in Editor.MOBs)
                {
                   lbNpc.Items.Add(MOB.name); 
                }
            }
            catch
            {
                MessageBox.Show("Erro ao adicionar os MOB's");
            }
            try
            {
                Editor.ReadNpc();
                foreach (STRUCT_MOB NPC in Editor.NPCs)
                {
                    lbNpc2.Items.Add(NPC.name);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao adicionar os NPC's");
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

        // Controle de MOB's
        private void lbNpc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = lbNpc.SelectedIndex;

            if (index < 0)
                return;

            // Informações do MOB
            txtNome.Text = Editor.MOBs[index].name.ToString();
            txtRace.Text = Editor.MOBs[index].Clan.ToString();
            txtMerchant.Text = Editor.MOBs[index].Merchant.ToString();
            txtClasse.Text = Editor.MOBs[index].Class.ToString();
            txtMoney.Text = Editor.MOBs[index].Coin.ToString();
            txtExp.Text = Editor.MOBs[index].Exp.ToString();
            txtPosX.Text = Editor.MOBs[index].SPX.ToString();
            txtPosY.Text = Editor.MOBs[index].SPY.ToString();
            txtSkill.Text = Editor.MOBs[index].SkillBar[0].ToString() + " " + Editor.MOBs[index].SkillBar[1].ToString() + " " + Editor.MOBs[index].SkillBar[2].ToString() + " " + Editor.MOBs[index].SkillBar[3].ToString();
            txtLearn.Text = Editor.MOBs[index].LearnedSkill.ToString();
            txtRegenHP.Text = Editor.MOBs[index].RegenHP.ToString();
            txtRegenMP.Text = Editor.MOBs[index].RegenMP.ToString();
            txtResist.Text = Editor.MOBs[index].Resist[0].ToString() + " " + Editor.MOBs[index].Resist[1].ToString() + " " + Editor.MOBs[index].Resist[2].ToString() + " " + Editor.MOBs[index].Resist[3].ToString();
            txtDirect.Text = Editor.MOBs[index].BaseScore.Speed.ToString();
            txtBonus.Text = Editor.MOBs[index].ScoreBonus.ToString();

            // informações do equipe do mob
            foreach (Control gp in Equips.Controls)
            {
                if (gp is TextBox)
                {
                    gp.Text = Editor.MOBs[index].Equip[gp.TabIndex].sIndex.ToString() + " " +
                    Editor.MOBs[index].Equip[gp.TabIndex].sEffect[0].cEfeito.ToString() + " " +
                    Editor.MOBs[index].Equip[gp.TabIndex].sEffect[0].cValue.ToString() + " " +
                    Editor.MOBs[index].Equip[gp.TabIndex].sEffect[1].cEfeito.ToString() + " " +
                    Editor.MOBs[index].Equip[gp.TabIndex].sEffect[1].cValue.ToString() + " " +
                    Editor.MOBs[index].Equip[gp.TabIndex].sEffect[2].cEfeito.ToString() + " " +
                    Editor.MOBs[index].Equip[gp.TabIndex].sEffect[2].cValue.ToString();
                }
            }

            // Score do MOB
            txtLevel.Text = Editor.MOBs[index].BaseScore.Level.ToString();
            txtDef.Text = Editor.MOBs[index].BaseScore.Defesa.ToString();
            txtDano.Text = Editor.MOBs[index].BaseScore.Ataque.ToString();
            txtStr.Text = Editor.MOBs[index].BaseScore.Str.ToString();
            txtInt.Text = Editor.MOBs[index].BaseScore.Int.ToString();
            txtDex.Text = Editor.MOBs[index].BaseScore.Dex.ToString();
            txtCon.Text = Editor.MOBs[index].BaseScore.Con.ToString();
            txtHP.Text = Editor.MOBs[index].BaseScore.HP.ToString();
            txtMaxHP.Text = Editor.MOBs[index].BaseScore.MaxHP.ToString();
            txtMP.Text = Editor.MOBs[index].BaseScore.MP.ToString();
            txtMaxMP.Text = Editor.MOBs[index].BaseScore.MaxMP.ToString();
            txtNear.Text = Editor.MOBs[index].BaseScore.Special[0].ToString();
            txtMotion1.Text = Editor.MOBs[index].BaseScore.Special[1].ToString();
            txtFar.Text = Editor.MOBs[index].BaseScore.Special[2].ToString();
            txtMotion2.Text = Editor.MOBs[index].BaseScore.Special[3].ToString();

            //Informações do inventario do MOB
            foreach (Control tb2 in Inventario.Controls)
            {
                if (tb2 is TextBox)
                {
                    if (tb2.Enabled == true)
                    {
                        tb2.Text = Editor.MOBs[index].Carry[tb2.TabIndex].sIndex.ToString() + " " +
                        Editor.MOBs[index].Carry[tb2.TabIndex].sEffect[0].cEfeito.ToString() + " " +
                        Editor.MOBs[index].Carry[tb2.TabIndex].sEffect[0].cValue.ToString() + " " +
                        Editor.MOBs[index].Carry[tb2.TabIndex].sEffect[1].cEfeito.ToString() + " " +
                        Editor.MOBs[index].Carry[tb2.TabIndex].sEffect[1].cValue.ToString() + " " +
                        Editor.MOBs[index].Carry[tb2.TabIndex].sEffect[2].cEfeito.ToString() + " " +
                        Editor.MOBs[index].Carry[tb2.TabIndex].sEffect[2].cValue.ToString();
                    }

                    if (tb2.Enabled == false)
                    {
                        int Item = Editor.MOBs[index].Carry[tb2.TabIndex].sIndex;
                        tb2.Text = Editor.ItemList.item[Item].Name.ToString();
                    }
                }
            }
        }

        // Botão de salvar as informações do MOB
        private void button1_Click(object sender, EventArgs e)
        {
            //           Salvar informações do MOB
            if (lbNpc.SelectedIndex > 0)
            {
                STRUCT_MOB npc = Editor.MOBs[lbNpc.SelectedIndex];

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
                    if (textbox is TextBox)
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

                Editor.MOBs[lbNpc.SelectedIndex] = npc;
                Editor.SaveNPC(npc);          
            }
            else
            {
                MessageBox.Show("Selecione um mob para salvar!");
                return;
            }
        }

        // Responsavel pela mudança de nome do textbox do MOB
        private void textchange(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox == null)
                return;

            var itemName = Inventario.Controls.OfType<TextBox>().First(c => c.TabIndex == textBox.TabIndex && c.Enabled == false);

            Editor.MOBs[lbNpc.SelectedIndex].Carry[textBox.TabIndex].sIndex = Convert.ToInt16(textBox.Text.Split(' ')[0]);

            itemName.Text = Editor.ItemList.item[Editor.MOBs[lbNpc.SelectedIndex].Carry[textBox.TabIndex].sIndex].Name;
        }

        // Controle de NPC's
        private void lbNpc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = lbNpc2.SelectedIndex;

            // Informações do MOB
            txtNomeNPC.Text = Editor.NPCs[index].name.ToString();
            txtRaceNPC.Text = Editor.NPCs[index].Clan.ToString();
            txtMerchantNPC.Text = Editor.NPCs[index].Merchant.ToString();
            txtClassNPC.Text = Editor.NPCs[index].Class.ToString();
            txtMoneyNPC.Text = Editor.NPCs[index].Coin.ToString();
            txtExpNPC.Text = Editor.NPCs[index].Exp.ToString();
            txtPosXNPC.Text = Editor.NPCs[index].SPX.ToString();
            txtPosYNPC.Text = Editor.NPCs[index].SPY.ToString();
            txtSkillNPC.Text = Editor.NPCs[index].SkillBar[0].ToString() + " " + Editor.NPCs[index].SkillBar[1].ToString() + " " + Editor.NPCs[index].SkillBar[2].ToString() + " " + Editor.NPCs[index].SkillBar[3].ToString();
            txtLearnNPC.Text = Editor.NPCs[index].LearnedSkill.ToString();
            txtRegenHPNPC.Text = Editor.NPCs[index].RegenHP.ToString();
            txtRegenMPNPC.Text = Editor.NPCs[index].RegenMP.ToString();
            txtResistNPC.Text = Editor.NPCs[index].Resist[0].ToString() + " " + Editor.NPCs[index].Resist[1].ToString() + " " + Editor.NPCs[index].Resist[2].ToString() + " " + Editor.NPCs[index].Resist[3].ToString();
            txtVeloNPC.Text = Editor.NPCs[index].BaseScore.Speed.ToString();
            txtBonusNPC.Text = Editor.NPCs[index].ScoreBonus.ToString();

            // informações do equipe do mob
            foreach (Control gp in gbEquipes.Controls)
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
            txtLevelNPC.Text = Editor.NPCs[index].BaseScore.Level.ToString();
            txtDefNPC.Text = Editor.NPCs[index].BaseScore.Defesa.ToString();
            txtDanoNPC.Text = Editor.NPCs[index].BaseScore.Ataque.ToString();
            txtStrNPC.Text = Editor.NPCs[index].BaseScore.Str.ToString();
            txtIntNPC.Text = Editor.NPCs[index].BaseScore.Int.ToString();
            txtDexNPC.Text = Editor.NPCs[index].BaseScore.Dex.ToString();
            txtConNPC.Text = Editor.NPCs[index].BaseScore.Con.ToString();
            txtHPNPC.Text = Editor.NPCs[index].BaseScore.HP.ToString();
            txtMaxHPNPC.Text = Editor.NPCs[index].BaseScore.MaxHP.ToString();
            txtMPNPC.Text = Editor.NPCs[index].BaseScore.MP.ToString();
            txtMaxMPNPC.Text = Editor.NPCs[index].BaseScore.MaxMP.ToString();
            txtNearNPC.Text = Editor.NPCs[index].BaseScore.Special[0].ToString();
            txtMotion1NPC.Text = Editor.NPCs[index].BaseScore.Special[1].ToString();
            txtFarNPC.Text = Editor.NPCs[index].BaseScore.Special[2].ToString();
            txtMotion2NPC.Text = Editor.NPCs[index].BaseScore.Special[3].ToString();

             //Informações do inventario do MOB
            foreach (Control tb2 in InventarioNPC.Controls)
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

        // Botão de salvar as informações do NPC
        private void button2_Click(object sender, EventArgs e)
        {
            // Salvar informações do NPC
            if (lbNpc2.SelectedIndex > 0)
            {
                STRUCT_MOB npc = Editor.NPCs[lbNpc2.SelectedIndex];

                npc.name = txtNomeNPC.Text.ToString();
                npc.Clan = Convert.ToByte(txtRaceNPC.Text.ToString());
                npc.Merchant = Convert.ToByte(txtMerchantNPC.Text.ToString());
                npc.Class = Convert.ToByte(txtClassNPC.Text.ToString());
                npc.Coin = Convert.ToInt32(txtMoneyNPC.Text.ToString());
                npc.Exp = Convert.ToInt64(txtExpNPC.Text.ToString());
                npc.SPX = Convert.ToInt16(txtPosXNPC.Text.ToString());
                npc.SPY = Convert.ToInt16(txtPosYNPC.Text.ToString());
                string texto = txtSkillNPC.Text;
                string[] split = texto.Split(' ');
                npc.SkillBar[0] = Convert.ToByte(split[0]);
                npc.SkillBar[1] = Convert.ToByte(split[1]);
                npc.SkillBar[2] = Convert.ToByte(split[2]);
                npc.SkillBar[3] = Convert.ToByte(split[3]);
                npc.LearnedSkill = Convert.ToUInt64(txtLearnNPC.Text.ToString());
                npc.RegenHP = Convert.ToInt16(txtRegenHPNPC.Text.ToString());
                npc.RegenMP = Convert.ToInt16(txtRegenMPNPC.Text.ToString());
                string texto2 = txtResistNPC.Text;
                string[] split2 = texto2.Split(' ');
                npc.Resist[0] = Convert.ToByte(split2[0]);
                npc.Resist[1] = Convert.ToByte(split2[1]);
                npc.Resist[2] = Convert.ToByte(split2[2]);
                npc.Resist[3] = Convert.ToByte(split2[3]);
                npc.BaseScore.Speed = Convert.ToByte(txtVeloNPC.Text.ToString());
                npc.ScoreBonus = Convert.ToInt16(txtBonusNPC.Text.ToString());


                // Salvar Informações do Score do MOB
                npc.BaseScore.Level = Convert.ToInt32(txtLevelNPC.Text.ToString());
                npc.BaseScore.Defesa = Convert.ToInt32(txtDefNPC.Text.ToString());
                npc.BaseScore.Ataque = Convert.ToInt32(txtDanoNPC.Text.ToString());
                npc.BaseScore.Str = Convert.ToInt16(txtStrNPC.Text.ToString());
                npc.BaseScore.Int = Convert.ToInt16(txtIntNPC.Text.ToString());
                npc.BaseScore.Dex = Convert.ToInt16(txtDexNPC.Text.ToString());
                npc.BaseScore.Con = Convert.ToInt16(txtConNPC.Text.ToString());
                npc.BaseScore.HP = Convert.ToInt32(txtHPNPC.Text.ToString());
                npc.BaseScore.MaxHP = Convert.ToInt32(txtMaxHPNPC.Text.ToString());
                npc.BaseScore.MP = Convert.ToInt32(txtMPNPC.Text.ToString());
                npc.BaseScore.MaxMP = Convert.ToInt32(txtMaxMPNPC.Text.ToString());
                npc.BaseScore.Special[0] = Convert.ToInt16(txtNearNPC.Text.ToString());
                npc.BaseScore.Special[1] = Convert.ToInt16(txtMotion1NPC.Text.ToString());
                npc.BaseScore.Special[2] = Convert.ToInt16(txtFarNPC.Text.ToString());
                npc.BaseScore.Special[3] = Convert.ToInt16(txtMotion2NPC.Text.ToString());


                // Salvar informações do Equipamento do MOB
                foreach (Control gp in gbEquipes.Controls)
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
                // Salvar o Inventario do NPC
                foreach (Control textbox in InventarioNPC.Controls)
                {
                    if (textbox is TextBox)
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

                MessageBox.Show(string.Format("O npc {0} foi salvo com sucesso!", npc.name));

                Editor.NPCs[lbNpc2.SelectedIndex] = npc;
                Editor.SaveNPC(npc);
            }
            else
            {
                MessageBox.Show("Selecione um npc para salvar!");
                return;
            }
        }

        // Responsavel pela mudança de nome do textbox dos Npc's
        private void textchange2(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox == null)
                return;

            var itemName = InventarioNPC.Controls.OfType<TextBox>().First(c => c.TabIndex == textBox.TabIndex && c.Enabled == false);

            Editor.NPCs[lbNpc2.SelectedIndex].Carry[textBox.TabIndex].sIndex = Convert.ToInt16(textBox.Text.Split(' ')[0]);

            itemName.Text = Editor.ItemList.item[Editor.NPCs[lbNpc2.SelectedIndex].Carry[textBox.TabIndex].sIndex].Name;
        }
      
        // Gerar DropList
        private void gerarArquivoTxTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("DropList.txt"); // Gera o dropList no mesmo local do programa 
            List<string> DropList = new List<string>();
            try
            {
                foreach (STRUCT_MOB MOB in Editor.MOBs)
                {
                    List<string> Drop = new List<string>();

                    int value = 0;

                    Drop.Add(String.Format("MOB: {0},", MOB.name));

                    for (int i = 0; i < 64; i++)
                    {
                        if (MOB.Carry[i].sIndex <= 0 || MOB.Carry[i].sIndex > 6500)
                            continue;

                        if (value > 0)
                            Drop.Add(",");

                        Drop.Add(String.Format("{0}", Editor.ItemList.item[MOB.Carry[i].sIndex].Name));
                        value++;
                    }

                    if (value > 0)
                        Drop.Add(",");

                    Drop.Add(String.Format("{0},", MOB.BaseScore.Ataque));
                    Drop.Add(String.Format("{0}", MOB.BaseScore.Defesa));

                    if (value > 0)
                    {
                        Drop.Add("\r\n\r\n\r\n");
                        DropList.AddRange(Drop);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (string value in DropList)
                sw.Write(value);

            sw.Close();
            MessageBox.Show("DropList gerado com sucesso!");
        }

        // Abrir form para localizar itens dos MOB's
        private void LocalizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Localizador localizador = new Localizador(this);
            localizador.ShowDialog();
        }
    }
}
