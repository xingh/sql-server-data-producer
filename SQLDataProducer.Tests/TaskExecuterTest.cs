﻿// Copyright 2012-2014 Peter Henell

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using NUnit.Framework;
using SQLDataProducer.Entities.DataConsumers;
using SQLDataProducer.Entities.ExecutionEntities;
using SQLDataProducer.Entities.OptionEntities;
using SQLDataProducer.TaskExecuter;
using System.Collections.Generic;
using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SQLDataProducer.Tests
{
    [TestFixture]
    [MSTest.TestClass]
    public class TaskExecuterTest
    {
        string connectionString = "";
        IDataConsumer consumer = new MockDataConsumer();
        Dictionary<string, string> consumerOptions = new Dictionary<string,string>();

        ExecutionResultBuilder builder = new ExecutionResultBuilder();
        ExecutionTaskOptions options = new ExecutionTaskOptions();
        ExecutionNode rootNode = ExecutionNode.CreateLevelOneNode(1, "Root");


        [Test]
        [MSTest.TestMethod]
        public void ShouldInstantiateTaskExecuter()
        {
           // TaskExecuter.TaskExecuter executor = new TaskExecuter.TaskExecuter(null, null, null, null, null);

        }
    }
}

