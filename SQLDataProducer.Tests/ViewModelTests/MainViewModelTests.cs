﻿using NUnit.Framework;
using SQLDataProducer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SQLDataProducer.ViewModels;
using SQLDataProducer.RandomTests;
using System.Threading;
using SQLDataProducer.Entities.DatabaseEntities;
using SQLDataProducer.Helpers;


namespace SQLDataProducer.RandomTests.ViewModelTests
{
    [TestFixture]
    public class MainViewModelTests : TestBase
    {

        MainWindowViewModel mainVM;
        Model.ApplicationModel model;

        public MainViewModelTests()
            : base()
        {
            //model = new Model.ApplicationModel();
            var options = new Entities.OptionEntities.ExecutionTaskOptions();

            options.ExecutionType = Entities.ExecutionTypes.ExecutionCountBased;
            options.FixedExecutions = 1;

            mainVM = new MainWindowViewModel(options);

            model = mainVM.Model;
            model.ConnectionString = Connection();
        }

        [Test]
        [Ignore]
        public void ShouldRun_LoadCommand()
        {
            // Cant test, is showing windows GUI
        }

        [Test]
        public void ShouldRun_LoadTablesCommand()
        {
            mainVM.LoadTablesCommand.Execute();
            MainViewModelDoEventsUntilQueryIsDone();
            Assert.That(mainVM.Model.Tables.Count, Is.GreaterThan(0));

        }

        private void MainViewModelDoEventsUntilQueryIsDone()
        {
            while (mainVM.Model.IsQueryRunning)
            {
                Thread.Sleep(10);
                DispatcherSupplier.DispatcherUtil.DoEvents();

            }
        }
        
        [Test]
        [Ignore]
        public void ShouldRun_RunCommand()
        {
            // cannot test, is showing windows
        }

        [Test]
        [Ignore]
        public void ShouldRun_SaveCommand()
        {
            // Cant test, is showing windows GUI
        }

    }
}
