// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using EFCodeFirstDemo.Data.EF;
using EFCodeFirstDemo.Data.EF.Repositories;
using EFCodeFirstDemo.Domain;
using EFCodeFirstDemo.RepositoryInterfaces;
using SSW.Framework.Data.EF;
using SSW.Framework.Data.Interfaces;
using StructureMap;
namespace EFCodeFirstDemo.WebUI.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });


                            // configure DB Context
                            //x.For<IDatabaseInitializer<DemoDbContext>>().Use<DropCreateInitializer>();
                            
                            x.For<DbMigrationsConfiguration<DemoDbContext>>().Use<EFCodeFirstDemo.Data.EF.Migrations.Configuration>();
                            x.For<IDatabaseInitializer<DemoDbContext>>().Use<UpdateMigrationsInitializer<DemoDbContext>>();


                            x.For<SSW.Framework.Data.EF.IDbContextFactory<DemoDbContext>>().Use<DemoDbContextFactory>()
                                .Ctor<string>().Is(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                            x.For<IDbContextManager>().HybridHttpOrThreadLocalScoped().Use<DbContextManager<DemoDbContext>>();


                            // Wire all DB Contexts to UnitOfWork
                            x.For<IEnumerable<IDbContextManager>>()
                                .Use(c => c.GetAllInstances<IDbContextManager>());
                            x.For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork>();


                            // configure repositories
                            x.For<ICustomerRepository>().Use<CustomerRepository>();


                        });

            return ObjectFactory.Container;
        }
    }
}