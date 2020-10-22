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
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.ServiceModel.Syndication;

namespace RSS_Youtube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("apa");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                XmlReader FD_readxml = XmlReader.Create(textBox1.Text);
                SyndicationFeed FD_feed = SyndicationFeed.Load(FD_readxml);

                TabPage FD_tab = new TabPage(FD_feed.Title.Text);


                tabControl1.TabPages.Add(FD_tab);

                ListBox FD_list = new ListBox();

                FD_tab.Controls.Add(FD_list);

                FD_list.Dock = DockStyle.Fill;

               

                FD_list.HorizontalScrollbar = true;

                foreach (SyndicationItem FD_item  in FD_feed.Items)
                {
                   string summary = FD_item.Summary.Text;
                    bool running = true;

                    string fix_sum = "";

                    foreach (char characterdata in summary)
                    {
                        if(characterdata != '<' && running )
                        {
                            fix_sum = fix_sum + characterdata;
                        }
                        else
                        {
                            running = false;
                        }
                    }
                    
                    FD_list.Items.Add(FD_item.Title.Text);
                    FD_list.Items.Add(fix_sum);
                    FD_list.Items.Add("-----------");
                }
               
            }
            catch 
            {

                
            }


        }
    }
}
