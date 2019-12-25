﻿using System;
using Unity.Builder;
using Unity.Events;
using Unity.Extension;
using Unity.Lifetime;
using Unity.Policy;
using Unity.Processors;
using Unity.Storage;
using Unity.Strategies;

namespace Unity
{
    public partial class UnityContainer
    {
        #region Defaults

        internal static readonly DefaultPolicies Defaults;

        #endregion


        static UnityContainer()
        {
            // Initialize defaults
            Defaults = new DefaultPolicies(

            //// Constructor selectors
            //new StagedStrategyChain<SelectorDelegate<ConstructorInfo, InjectionMember, object?>, SelectionStage>
            //{
            //},

            //// Field selectors
            //new StagedStrategyChain<MemberSelector<FieldInfo, InjectionMember>, SelectionStage>
            //{
            //},

            //// Property selectors
            //new StagedStrategyChain<MemberSelector<PropertyInfo, InjectionMember>, SelectionStage>
            //{
            //},

            //// Method selectors
            //new StagedStrategyChain<MemberSelector<MethodInfo, InjectionMember>, SelectionStage>
            //{
            //}
            );
        }
    }
}
