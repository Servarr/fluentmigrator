#region License
// Copyright (c) 2007-2024, Fluent Migrator Project
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;

using FluentMigrator.Runner.Generators.MySql;

namespace FluentMigrator.Runner.Processors.MySql
{
    public class MySql8ProcessorFactory : MigrationProcessorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MySql8ProcessorFactory()
            : this(serviceProvider: null)
        {
        }

        public MySql8ProcessorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [Obsolete]
        public override IMigrationProcessor Create(string connectionString, IAnnouncer announcer, IMigrationProcessorOptions options)
        {
            var factory = new MySqlDbFactory(_serviceProvider);
            var connection = factory.CreateConnection(connectionString);
            return new MySqlProcessor(connection, new MySql8Generator(new MySqlQuoter()), announcer, options, factory);
        }
    }
}
