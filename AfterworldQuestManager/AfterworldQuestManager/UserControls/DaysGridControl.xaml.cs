using AfterworldQuestManager.Models;
using AfterworldQuestManager.ViewModels;
using AfterworldQuestManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AfterworldQuestManager.UserControls
{
    public partial class DaysGridControl : Grid
    {

        static List<Days>  d;
        static List<Label> labels = new List<Label>();
        static List<Entry> entrys = new List<Entry>();

        public DaysGridControl()
        {
            InitializeComponent();
        }

        public static BindableProperty DaysProperty =
            BindableProperty.Create(nameof(Days), typeof(List<Days>), typeof(DaysGridControl), null,
                BindingMode.OneWay, null, OnDaysChanged);


        static void CheckValidQuests(string str, ref Entry entry)
        {
            try
            {
                if (str == "")
                {
                    return;
                }

                bool PaintRed = false;
                string[] subs = str.Split(',');

                foreach (string s in subs)
                {
                    if (s == "")
                    {
                        PaintRed = true;
                        continue;
                    }

                    DatabaseSingleton ds = DatabaseSingleton.GetInstance();
                    int searchid = Convert.ToInt32(s);

                    List<Quests> q = ds.db.Table<Quests>().Where(p => p.id == searchid).ToList();

                    if (q.Count() == 0)
                    {
                        PaintRed = true;
                        break;
                    }
                }

                if (PaintRed)
                {
                    entry.TextColor = Color.Red;
                }
                else
                {
                    entry.TextColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

        }

        static void OnTextChanged(object sender, EventArgs e)
        {
            Entry entry = sender as Entry;
            String val = entry.Text;
            String newStr = "";

            foreach (char v in val)
            {
                if (Char.IsDigit(v) || v == ',')
                {
                    newStr += v;
                }
            }

            CheckValidQuests(newStr, ref entry);

            int i;
            for (i = 0; i < entrys.Count();i++)
            {
                if (entrys[i] == entry)
                {
                    break;
                }
            }
            if (i != entrys.Count())
            {
                d[i].quests = newStr;

                DatabaseSingleton ds = DatabaseSingleton.GetInstance();

                ds.db.Update(d[i]);
            }

            entry.Text = newStr;     
        }

        private static void OnDaysChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
          var control = (DaysGridControl)bindable;
            if (control != null)
            {
                if (newvalue is List<Days> days)
                {
                    d = days;

                    var rowNumber = -1;

                    labels.Clear();
                    entrys.Clear();

                    foreach (var day in days)
                    {
                        Label l = new Label { Text = day.day.ToString(), FontSize = 24 };
                        Entry e = new Entry { Text = day.quests, FontSize = 24 };

                        labels.Add(l);
                        entrys.Add(e);

                        CheckValidQuests(day.quests, ref e);

                        e.TextChanged += OnTextChanged;
   
                        rowNumber++;
                        control.RowDefinitions.Add(new RowDefinition { Height = 50 });
                        control.Children.Add(l, 0, rowNumber);
                        control.Children.Add(e, 1, rowNumber);

                    }
                }
            }
        }

        public List<Days> Days
        {
            get => (List<Days>)GetValue(DaysProperty);
            set => SetValue(DaysProperty, value);
        }
    }
}