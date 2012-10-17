﻿// Copyright 2012 Peter Henell

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDataProducer.Entities.ExecutionEntities;
using SQLDataProducer.EntityQueryGenerator;
using SQLDataProducer.DataAccess;

namespace SQLDataProducer.ContinuousInsertion
{
    //public class ContinuousInsertionManager
    //{
    //    readonly string ConnectionString { get; set; }

    //    public ContinuousInsertionManager(string connectionString)
    //    {
    //        ConnectionString = connectionString;
    //    }

    //    public void DoOneExecution(ExecutionItemCollection items, Func<int> getN)
    //    {
    //        var adhd = new AdhocDataAccess(ConnectionString);
    //        foreach (var ei in items)
    //        {
    //            //if (ei.TargetTable.HasForeignKey)
    //            for (int i = 0; i < ei.RepeatCount; i++)
    //            {
    //                long n = getN();
    //                if (!ei.ShouldExecuteOnThisN(n))
    //                    return;

    //                string insertQuery = ei.GenerateInsertQuery(n, items);

    //                if (ei.TargetTable.HasIdentityColumn)
    //                {
    //                    var fk = adhd.ExecuteIdentityQuery(insertQuery);

    //                    ei.TargetTable.LastInsertedIdentityValue = fk.IdentityValue;

                        
    //                }
    //                else
    //                {
    //                    adhd.ExecuteNonQuery(insertQuery);
    //                }

    //                if (items.IsTableReferenced(ei.TargetTable))
    //                    ForeignKeyManager.Instance.AddKeyToTable(ei.TargetTable, fk.IdentityValue);
                     
                    
    //            }
                
                    
    //        }
    //    }
    //}
}