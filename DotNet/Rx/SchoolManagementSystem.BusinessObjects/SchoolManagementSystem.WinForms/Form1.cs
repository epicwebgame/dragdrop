using SchoolManagementSystem.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var schools = new List<School>();
            int num = 0;

            var observableSchools = Observable.Generate(1, i => i <= 3, i => i + 1, i =>
            {
                // Debugger.Break();
                // Debug.Print(Thread.CurrentThread.IsBackground.ToString());

                var school = new School(string.Format($"School {i}"));
                school.FillWithStudents(10);

                // Thread.Sleep(200);

                schools.Add(school);

                return school;
            });

            // var connectibleObservableOfSchools = observableSchools.Publish();

            //observableSchools.ObserveOn(this).Subscribe((School school) =>
            //{
            //    this.Text = SynchronizationContext.Current?.GetType().Name ?? "Null";

            //    var control = this.Controls.Find(string.Format($"lstSchool{++num}"), true)?.FirstOrDefault();
            //    if (control != null)
            //    {
            //        var lst = control as ListBox;
            //        if (lst != null)
            //        {
            //            lst.Items.Clear();
            //            lst.Items.Add(school.Name);

            //            foreach (var student in school.Take(10))
            //            {
            //                lst.Items.Add(student.ToString());
            //            }
            //        }
            //    }
            //});

            // observableSchools.Wait();

            var sub1 = observableSchools.FirstAsync().ObserveOn(this).Subscribe((School school) =>
            {
                this.Text = SynchronizationContext.Current?.GetType().Name ?? "Null";

                lstSchool1.Items.Clear();
                lstSchool1.Items.Add(school.Name);

                foreach (var student in school.Take(10))
                {
                    lstSchool1.Items.Add(student.ToString());
                }
            });

        //    var sub2 = observableSchools.SubscribeOn(Scheduler.Default).ObserveOn(this).Subscribe((School school) =>
        //    {
        //        this.Text = SynchronizationContext.Current?.GetType().Name ?? "Null";

        //        lstSchool2.Items.Clear();
        //        lstSchool2.Items.Add(school.Name);

        //        foreach (var student in school.Take(10))
        //        {
        //            lstSchool2.Items.Add(student.ToString());
        //        }
        //    });

        //    var sub3 = observableSchools.SubscribeOn(Scheduler.Default).ObserveOn(this).Subscribe((School school) =>
        //    {
        //        this.Text = SynchronizationContext.Current?.GetType().Name ?? "Null";

        //        lstSchool3.Items.Clear();
        //        lstSchool3.Items.Add(school.Name);

        //        foreach (var student in school.Take(10))
        //        {
        //            lstSchool3.Items.Add(student.ToString());
        //        }
        //    });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var query = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove")
                .Where(ep => ep.EventArgs.X == ep.EventArgs.Y);
            query.Subscribe(ep => { this.Text = ep.EventArgs.Location.ToString(); });
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
