// -------------------------------------------------------------------------------------------------
// <copyright file="IFilterBindingInSyntax.cs" company="Ninject Project Contributors">
//   Copyright (c) 2007-2010 Enkari, Ltd. All rights reserved.
//   Copyright (c) 2010-2017 Ninject Project Contributors. All rights reserved.
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   You may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Web.WebApi.FilterBindingSyntax
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    using Ninject.Activation;
    using Ninject.Syntax;

    /// <summary>
    /// Used to define the scope in which instances activated via a binding should be re-used.
    /// </summary>
    /// <typeparam name="T">The service being bound.</typeparam>
    public interface IFilterBindingInSyntax<out T> : IBindingSyntax
    {
        /// <summary>
        /// Indicates that only a single instance of the binding should be created, and then
        /// should be re-used for all subsequent requests.
        /// </summary>
        /// <returns>The fluent syntax to define more information</returns>
        IFilterBindingNamedWithOrOnSyntax<T> InSingletonScope();

        /// <summary>
        /// Indicates that instances activated via the binding should not be re-used, nor have
        /// their life cycle managed by Ninject.
        /// </summary>
        /// <returns>The fluent syntax to define more information</returns>
        IFilterBindingNamedWithOrOnSyntax<T> InTransientScope();

        /// <summary>
        /// Indicates that instances activated via the binding should be re-used within the same thread.
        /// </summary>
        /// <returns>The fluent syntax to define more information</returns>
        IFilterBindingNamedWithOrOnSyntax<T> InThreadScope();

        /// <summary>
        /// Indicates that instances activated via the binding should be re-used within the same
        /// HTTP request.
        /// </summary>
        /// <returns>The fluent syntax to define more information</returns>
        IFilterBindingNamedWithOrOnSyntax<T> InRequestScope();

        /// <summary>
        /// Indicates that instances activated via the binding should be re-used as long as the object
        /// returned by the provided callback remains alive (that is, has not been garbage collected).
        /// </summary>
        /// <param name="scope">The callback that returns the scope.</param>
        /// <returns>The fluent syntax to define more information</returns>
        IFilterBindingNamedWithOrOnSyntax<T> InScope(Func<IContext, object> scope);

        /// <summary>
        /// Indicates that instances activated via the binding should be re-used as long as the object
        /// returned by the provided callback remains alive (that is, has not been garbage collected).
        /// </summary>
        /// <param name="scope">The callback that returns the scope.</param>
        /// <returns>The fluent syntax to define more information</returns>
        IFilterBindingNamedWithOrOnSyntax<T> InScope(Func<IContext, HttpConfiguration, HttpActionDescriptor, object> scope);
    }
}