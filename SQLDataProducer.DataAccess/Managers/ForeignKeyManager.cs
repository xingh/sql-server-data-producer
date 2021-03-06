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

using System.Linq;
using SQLDataProducer.Entities.DatabaseEntities;
using System.Collections.ObjectModel;
using SQLDataProducer.DataAccess;
using SQLDataProducer.Entities.DatabaseEntities.Collections;
using System;

namespace SQLDataProducer.EntityQueryGenerator
{
    public class ForeignKeyManager
    {
        ObservableCollection<ForeignKeyContainer> ForeignKeyContainerCache { get; set; }

        static readonly ForeignKeyManager _instance = new ForeignKeyManager();

        public static ForeignKeyManager Instance
        {
            get
            {
                return _instance;
            }
        }

        static ForeignKeyManager()
        {
        }

        ForeignKeyManager()
        {
            ForeignKeyContainerCache = new ObservableCollection<ForeignKeyContainer>();
        }

        /// <summary>
        /// When a new row is inserted in the table, add the key to the cache
        /// </summary>
        /// <param name="table"></param>
        /// <param name="insertedKey"></param>
        public void AddKeyToTable(TableEntity table, long insertedKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get available foreign keys in the table for the target column
        /// </summary>
        /// <param name="tda">the tableEntityDataAccess to use to fetch the foreign keys from database</param>
        /// <param name="table">the table from wich to get the keys</param>
        /// <param name="primaryKeyColumn">the key column to get keys for</param>
        /// <returns>a ObservableCollection<string> with the keys for the table</returns>
        /// <remarks>keys will be cached for next time they are requested.</remarks>
        public ObservableCollection<string> GetPrimaryKeysForTable(TableEntityDataAccess tda, TableEntity table, string primaryKeyColumn)
        {
            ObservableCollection<string> fkeys;

            ForeignKeyContainer cached = ForeignKeyContainerCache.Where(x => x.Table.FullName == table.FullName).FirstOrDefault();
            if (cached != null)
            {
                fkeys = cached.KeyValues;
            }
            else
            {
                fkeys = tda.GetPrimaryKeysForColumnInTable(table, primaryKeyColumn);
                ForeignKeyContainerCache.Add(new ForeignKeyContainer(table, primaryKeyColumn, fkeys));
            }
            return fkeys;
        }
    }

    class ForeignKeyContainer
    {

        private TableEntity _table;
        public TableEntity Table
        {
            get { return _table; }
            set { _table = value; }
        }

        private ObservableCollection<string> _keyValues;
        public ObservableCollection<string> KeyValues
        {
            get { return _keyValues; }
            set { _keyValues = value; }
        }

        private string _keyColumnName;
        public string KeyColumnName
        {
            get { return _keyColumnName; }
            set { _keyColumnName = value; }
        }

        public ForeignKeyContainer(TableEntity table, string keyColumnName, ObservableCollection<string> keys)
        {
            this._table = table;
            this._keyValues = keys;
            this._keyColumnName = keyColumnName;
        }
    }
}
