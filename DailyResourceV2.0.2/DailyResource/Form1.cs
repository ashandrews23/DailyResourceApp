using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.IO;
using System.Data.SqlClient;

namespace DailyResource
{
    public partial class Form1 : Form
    {
        public string subject = "Daily resource - " + DateTime.Now.ToString();
        public string sendto = "";
        public string sendCC = "KR03;LB02"; //change to KR03;LB02 after testing
        public string message = "";
        static public bool autosend = true;
        public string sig;
        public bool CCaddin = true;
        public bool Admin = true;
        //public bool ProjectUD = false;

        public Form1()
        {
            InitializeComponent();
            Startup();
            adminOptionsONToolStripMenuItem.PerformClick();
        }

        public void CreateMailItem(string subject, string sendto, string message, string sendCC)
        {
            if (Environment.UserName.ToUpper() == "TP10")
            {
                sig = "Regards\n\nTyrone Pearce\nIT Process Developer\nfor TLT LLP\nD: +44 (0)333 006 0810\nF: +44 (0)333 006 0810\nwww.TLTsolicitors.com";

            }
            if (Environment.UserName.ToUpper() == "GS12")
            {
                sig = "Thanks\n\nGarrie Selway\nIT Process Developer\nExt: 61354";
            }
            if (Environment.UserName.ToUpper() == "GB06")
            {
                sig = "Thanks,\n\nGeorge.\n\nGeorge Braund\nIT Process Developer\nExt:61087";
            }
            if (Environment.UserName.ToUpper() == "AA09")
            {
                sig = "Thanks,\n\nAsh\n\nAshley Andrews\nIT Process Developer\nExt: 61086";
            }
            if (Environment.UserName.ToUpper() == "DM16")
            {
                sig = "Thanks,\n\nDrew Musgrove\nIT Process Developer\nExt: 61135";
            }
            message = message + "\n" + sig;

            Microsoft.Office.Interop.Outlook.Application mailApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)mailApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = subject;
            mailItem.To = sendto;
            mailItem.CC = sendCC;
            mailItem.Body = message;
            mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceLow;
            //mailItem.HTMLBody = message;
            if (autosend == false)
            {
                mailItem.Display(true);
                
            }
            else
            {
                mailItem.Send();
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (!checkBoxAshley.Checked && !checkBoxDrew.Checked && !checkBoxGarrie.Checked && !checkBoxGeorge.Checked && !checkBoxTyrone.Checked)
            {
                MessageBox.Show("Please select at least one colleague to provide resource");
            }
            else
            {
            message = "";
            message = "Hi all,\n\nPlease see today's estimated resource below:\n";
                        foreach (Control check in Controls)
                        {
                            if (check is TextBox && check.Enabled)
                            {
                                if (!sendto.Contains("AA09;"))
                                {

                                    if (checkBoxAshley.Checked)
                                    {
                                        sendto += "AA09;";
                                    }

                                }

                                if (!sendto.Contains("DM16;"))
                                {

                                    if (checkBoxDrew.Checked)
                                    {
                                        sendto += "DM16;";
                                    }

                                }

                                if (!sendto.Contains("TP10;"))
                                {

                                    if (checkBoxTyrone.Checked)
                                    {
                                        sendto += "TP10;";
                                    }

                                }

                                if (!sendto.Contains("GB06;"))
                                {

                                    if (checkBoxGeorge.Checked)
                                    {
                                        sendto += "GB06;";
                                    }

                                }

                                if (!sendto.Contains("GS12;"))
                                {

                                    if (checkBoxGarrie.Checked)
                                    {
                                        sendto += "GS12;";
                                    }

                                }

                                string paddedleft = check.Name.PadRight(13);
                                string paddedright = check.Text.ToString().PadLeft(19);
                                message = message + "\n" + paddedleft + "-" + paddedright + "\n";
                            }
                        }
                        
                        var DayOfWeek = System.DateTime.Now.DayOfWeek.ToString();
                        //if (DayOfWeek == "Tuesday") //Amended options and email body for Project Updates email
                        //{
                        //    autoSendONToolStripMenuItem.Text = "Auto send: OFF";
                        //    autosend = false;
                        //    ProjectUD = true;
                        //    message = message + "\nPlease can you also send me your weekly project updates. Last week's updates are attached. Please ensure your updates are highlighted.\n";
                        //    sendto = "IT - Process Amendments;"; //Includes the Scotland developers as these need to be included in the Project Updates email
                        //    sendCC = "";
                        //}

                        string Username = "";

                        if (Environment.UserName.ToUpper() == "TP10")
                        {
                            sig = "Regards\n\nTyrone Pearce\nIT Process Developer\nfor TLT LLP\nD: +44 (0)333 006 0810\nF: +44 (0)333 006 0810\nwww.TLTsolicitors.com";
                            Username = "Tyrone";
                        }
                        if (Environment.UserName.ToUpper() == "GS12")
                        {
                            sig = "Thanks\n\nGarrie Selway\nIT Process Developer\nExt: 61354";
                            Username = "Garrie";
                        }
                        if (Environment.UserName.ToUpper() == "GB06")
                        {
                            sig = "Thanks,\n\nGeorge.\n\nGeorge Braund\nIT Process Developer\nExt:61087";
                            Username = "George";
                        }
                        if (Environment.UserName.ToUpper() == "AA09")
                        {
                            sig = "Thanks,\n\nAsh\n\nAshley Andrews\nIT Process Developer\nExt: 61086";
                            Username = "Ashley";
                        }
                        if (Environment.UserName.ToUpper() == "DM16")
                        {
                            sig = "Thanks,\n\nDrew Musgrove\nIT Process Developer\nExt: 61135";
                            Username = "Drew";
                        }

                        if (DayOfWeek == "Thursday")
                        {
                            string CABAttendee;
                            if (Username == cmbCABAttendee.Text)
                            {
                                CABAttendee = "me";
                            }
                            else
                            {
                                CABAttendee = cmbCABAttendee.Text;
                            }
                            message = message + "\nThe CAB attendee this Friday is " + CABAttendee + ". Please can you send " + CABAttendee + " any K2 development change request references.\n";
                        }

                        var SubmitValidation = true;
                        if ((checkBoxAshley.Checked && Ashley.Text == "") ||
                            (checkBoxDrew.Checked && Drew.Text == "") ||
                            (checkBoxGarrie.Checked && Garrie.Text == "") ||
                            (checkBoxGeorge.Checked && George.Text == "") ||
                            (checkBoxTyrone.Checked && Tyrone.Text == ""))
                        {
                            MessageBox.Show("Please enter an amount for all present developers");
                            SubmitValidation = false;                         
                        }
                        else
                        {
                            SubmitValidation = true;
                            //if (ProjectUD == true)
                            //{
                            //    MessageBox.Show("Please remember to attach the project updates request email before sending.");
                            //}
                            
                        }
                        if (DayOfWeek == "Thursday" && cmbCABAttendee.Text =="")
                        {
                            MessageBox.Show("Please select a CAB attendee");
                            SubmitValidation = false; 
                        }

                        if (SubmitValidation == true)
                        {
                            CreateMailItem(subject, sendto, message, sendCC);
                            

                            string connectionString = null;
                            //***LIVE TABLE CONNECTION***
                            connectionString = "Data Source=SQLDV02;Initial Catalog=DailyResource; Database=zTestAA09DailyResourceApp; integrated security=SSPI";
                            //***DEV TABLE CONNECTION*** 
                            //connectionString = "Data Source=SQLDV02;Initial Catalog=DailyResourceDEV; Database=zTestAA09DailyResourceApp; integrated security=SSPI";
                            // [ ] required as your fields contain spaces!!
                            string insStmt = "INSERT INTO DailyResource ([DateCreated], [Ashley], [Drew], [Garrie], [George], [Tyrone], [KatieOutOfOffice]) Values (GETDATE(), @Ashley, @Drew, @Garrie, @George, @Tyrone, @KatieOutOfOffice)";

                            using (SqlConnection cnn = new SqlConnection(connectionString))
                            {
                                cnn.Open();
                                SqlCommand insCmd = new SqlCommand(insStmt, cnn);
                                // use sqlParameters to prevent sql injection!
                                insCmd.Parameters.AddWithValue("@Ashley", Ashley.Text);
                                insCmd.Parameters.AddWithValue("@Drew", Drew.Text);
                                insCmd.Parameters.AddWithValue("@Garrie", Garrie.Text);
                                insCmd.Parameters.AddWithValue("@George", George.Text);
                                insCmd.Parameters.AddWithValue("@Tyrone", Tyrone.Text);
                                insCmd.Parameters.AddWithValue("@KatieOutOfOffice", checkBoxKatieOOO.Checked);
                                int affectedRows = insCmd.ExecuteNonQuery();
                                //MessageBox.Show(affectedRows + " rows inserted!");
                            }
                            this.Close();
                        
                        }
            }
            
        }

        private void Ashley_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Drew_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Garrie_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void George_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Tyrone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        
        private void weeklyCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string DevList = "";
            string LiveList = "";
            string EmailMessage = "";
            DateTime lastWeek = DateTime.Now.AddDays(-1);
            while (lastWeek.DayOfWeek != DayOfWeek.Saturday)
                lastWeek = lastWeek.AddDays(-1);

            string MyDoc = "c:\\reports\\Backup folders.txt";
            DateTime Temp = new DateTime(2018, 01, 12);
            var alldirsDev = Directory.GetDirectories(@"\\tltinternal.com\tlt\Backups\Solcase\Weekly DEV Dumps")
                .Select(x => new DirectoryInfo(x));
            var alldirsLive = Directory.GetDirectories(@"\\tltinternal.com\tlt\Backups\Solcase\Weekly LIVE Dumps")
                .Select(x => new DirectoryInfo(x));
            DateTime Starters = Directory.GetLastWriteTime(@"\\tltinternal.com\tlt\Backups\Solcase\Starters & Leavers Database - Backups");

            foreach (var dir in alldirsDev)
            {
                if (dir.LastWriteTime < lastWeek)
                {
                    if (dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly DEV Dumps\\BOI" && dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly DEV Dumps\\IEME" && dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly DEV Dumps\\UPGR" && dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly DEV Dumps\\System scripts removal - 28-06-16" && dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly DEV Dumps\\TRNG" )
                    {
                        DevList = DevList + dir.ToString() + "\n";
                        using (StreamWriter outputFile = new StreamWriter(MyDoc, true))
                        {
                            //outputFile.WriteLine(dir.ToString());
                        }
                    }
                }
            }
            foreach (var dir in alldirsLive)
            {
                if (dir.LastWriteTime < lastWeek)
                {
                    if (dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly LIVE Dumps\\BOI" && dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly LIVE Dumps\\IEME" && dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly LIVE Dumps\\UPGR" && dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly LIVE Dumps\\System scripts removal - 28-06-16" && dir.ToString() != "\\\\tltinternal.com\\tlt\\Backups\\Solcase\\Weekly LIVE Dumps\\TRNG")
                    {
                        LiveList = LiveList + dir.ToString() + "\n";
                        using (StreamWriter outputFile = new StreamWriter(MyDoc, true))

                        {
                            //outputFile.WriteLine(dir.ToString());
                        }
                    }
                }
            }
            if (Starters < lastWeek)
            {
                EmailMessage = EmailMessage + "Starter and leavers has not been ran \n\n";
            }

            if (DevList != "")
            {
                DevList = "Dev folders missed:\n" + DevList;
                EmailMessage = EmailMessage + DevList + "\n\n";
            }
            if (LiveList != "")
            {
                LiveList = "Live folders missed:\n" + LiveList;
                EmailMessage = EmailMessage + LiveList + "\n\n";
            }
            if (EmailMessage != "")
            {
                Microsoft.Office.Interop.Outlook.Application mailApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)mailApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = "Weekly Backup Check";
                mailItem.To = Environment.UserName;
                mailItem.Body = EmailMessage;
                mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceLow;
                mailItem.Send();

                MessageBox.Show("Issues found");
            }
            else
            {
                MessageBox.Show("No Issues found");
            }
        }

        public void Startup()
        {
            CenterToScreen();
            var DayOfWeek = System.DateTime.Now.DayOfWeek.ToString();
            if (DayOfWeek == "Tuesday")
            {
                autoSendONToolStripMenuItem.Text = "Auto send: OFF";
                autosend = false;

            }
            if (DayOfWeek == "Thursday")
            {
                lblCABAttendee.Visible = true;
                cmbCABAttendee.Visible = true;


            }

        }

        private void checkBoxAshley_CheckedChanged(object sender, EventArgs e)
        {
                if (checkBoxAshley.Checked)
                {
                    Ashley.Enabled = true;
                    Ashley.Visible = true;
                }
                else
                {
                    Ashley.Enabled = false;
                    Ashley.Visible = false;
                }
        }

        private void checkBoxDrew_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDrew.Checked)
            {
                Drew.Enabled = true;
                Drew.Visible = true;
            }
            else
            {
                Drew.Enabled = false;
                Drew.Visible = false;
            }
        }

        private void checkBoxGarrie_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGarrie.Checked)
            {
                Garrie.Enabled = true;
                Garrie.Visible = true;
            }
            else
            {
                Garrie.Enabled = false;
                Garrie.Visible = false;
            }
        }

        private void checkBoxGeorge_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGeorge.Checked)
            {
                George.Enabled = true;
                George.Visible = true;
            }
            else
            {
                George.Enabled = false;
                George.Visible = false;
            }        
        }

        private void checkBoxTyrone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTyrone.Checked)
            {
                Tyrone.Enabled = true;
                Tyrone.Visible = true;
            }
            else
            {
                Tyrone.Enabled = false;
                Tyrone.Visible = false;
            }
        }

        private void Drew_TextChanged(object sender, EventArgs e)
        {
            if (Drew.Text == "8" || Drew.Text == "9")
            {
                MessageBox.Show("Please enter an amount of hours between 1-7");
                Drew.Text = "";
            }
           
            
        }

        private void Ashley_TextChanged(object sender, EventArgs e)
        {
            if (Ashley.Text == "8" || Ashley.Text == "9")
            {
                MessageBox.Show("Please enter an amount of hours between 1-7");
                Ashley.Text = "";
            }
        }

        private void Garrie_TextChanged(object sender, EventArgs e)
        {
            if (Garrie.Text == "8" || Garrie.Text == "9")
            {
                MessageBox.Show("Please enter an amount of hours between 1-7");
                Garrie.Text = "";
            }
        }

        private void George_TextChanged(object sender, EventArgs e)
        {
            if (George.Text == "8" || George.Text == "9")
            {
                MessageBox.Show("Please enter an amount of hours between 1-7");
                George.Text = "";
            }
        }

        private void Tyrone_TextChanged(object sender, EventArgs e)
        {
            if (Tyrone.Text == "8" || Tyrone.Text == "9")
            {
                MessageBox.Show("Please enter an amount of hours between 1-7");
                Tyrone.Text = "";
            }
        }

        private void removeCCONToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (CCaddin == true)
            {
                sendCC = "";
                MessageBox.Show("CC has been removed from the resource email","CC removed");
                CCaddin = false;
                removeCCONToolStripMenuItem.Text = "Add CC to emails";
            }
            else
            {
                sendCC = "KR03;LB02;"; //change to KR03;LB02 after testing
                MessageBox.Show("CC has been added to the resource email", "CC added");
                CCaddin = true;
                removeCCONToolStripMenuItem.Text = "Remove CC from emails";
            }
        }

        private void autoSendONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Admin)
            {
                Admin = false;
                autosend = false;
                autoSendONToolStripMenuItem.Text = "Auto send: OFF";
            }
            else
            {
                Admin = true;
                autosend = true;
                autoSendONToolStripMenuItem.Text = "Auto send: ON";
            }
        }

        private void checkBoxKatieOOO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKatieOOO.Checked) {

                if (CCaddin == true)
                {
                   sendCC = "LB02;"; //change to LB02 after testing
                }
            }
            else
            {
                sendCC = "KR03;LB02"; //change to KR03 after testing
            }
        }
     
        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Environment.UserName.ToUpper() == "AA09")
            {
                var newWindow = new Report();

                newWindow.Show();
            }
            else
            {
                MessageBox.Show("You do not have authorisation to access these reports","Restricted");
            }
                

        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Daily Resource Assistant©\n\nVerson 2.0.2\n\nCreated by Tyrone Pearce.\nEdited by Ashley Andrews.\n\nAll rights reserved", "About");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Welcome to the Daily Resource assistant!\n\nTo send out the teams resource during your meeting, simply untick any absent colleagues (if any) and input their resource.\n\nOnce this has been done, click the Submit button to send the resource email to Katie. If she is absent, tick the \"Is Katie out of office?\" tickbox to send the resource email to Lee.\n\nPlease see the admin options for the ability to remove Katie/Lee from the CC of the email and also the ability to turn the auto send of the email on/off.\n\nPlease speak to Tyrone Pearce regarding any issues or improvements.","Help");
        }

    }
}