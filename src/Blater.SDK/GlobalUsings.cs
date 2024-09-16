global using System.Diagnostics.CodeAnalysis;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using Blater.Models;
global using Blater.Extensions;
global using Blater.Interfaces;
global using Blater.Interfaces.BlaterAuthentication.Repositories;
global using Blater.Interfaces.BlaterAuthentication.Stores;

global using Blater.SDK;
global using Blater.SDK.Interfaces;
//Contracts
global using Blater.SDK.Contracts;
global using Blater.SDK.Contracts.Authentication;
global using Blater.SDK.Contracts.Common;
global using Blater.SDK.Contracts.UserRole.Request.Base;
//REST
global using Blater.SDK.Implementations.REST.BlaterAuthentication.Repositories;
global using Blater.SDK.Implementations.REST.BlaterAuthentication.Stores;
//global using Blater.SDK.Implementations.REST.BlaterDatabase.Repositories;
//global using Blater.SDK.Implementations.REST.BlaterDatabase.Stores;
global using Blater.SDK.Implementations.REST.BlaterKeyValue.Repositories;
global using Blater.SDK.Implementations.REST.BlaterKeyValue.Stores;
global using Blater.SDK.Implementations.REST.BlaterManagement.Repositories;
global using Blater.SDK.Implementations.REST.BlaterManagement.Stores;