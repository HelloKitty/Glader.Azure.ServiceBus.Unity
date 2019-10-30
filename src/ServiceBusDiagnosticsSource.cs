// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Glader.Azure.ServiceBus.Unity.Stubs;

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Azure.ServiceBus.Diagnostics;

    internal class ServiceBusDiagnosticSource
    {
        public const string DiagnosticListenerName = "Microsoft.Azure.ServiceBus";
        public const string BaseActivityName = "Microsoft.Azure.ServiceBus.";

        public const string ExceptionEventName = BaseActivityName + "Exception";
        public const string ProcessActivityName =  BaseActivityName + "Process";

        public const string ActivityIdPropertyName = "Diagnostic-Id";
        public const string CorrelationContextPropertyName = "Correlation-Context";
        public const string RelatedToTag = "RelatedTo";
        public const string MessageIdTag = "MessageId";
        public const string SessionIdTag = "SessionId";

        private readonly string entityPath;
        private readonly Uri endpoint;

        public ServiceBusDiagnosticSource(string entityPath, Uri endpoint)
        {
            this.entityPath = entityPath;
            this.endpoint = endpoint;
        }

        public static bool IsEnabled()
        {
            return false;
        }


        #region Send

        internal Activity SendStart(IList<Message> messageList)
        {
            Activity activity = Start("Send", () => new
                {
                    Messages = messageList,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetTags(a, messageList)
            );

            Inject(messageList);

            return activity;
        }

        internal void SendStop(Activity activity, IList<Message> messageList, TaskStatus? status)
        {
           
        }

        #endregion


        #region Process

        internal Activity ProcessStart(Message message)
        {
            return ProcessStart("Process", message, () => new
                {
                    Message = message,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetTags(a, message));
        }

        internal void ProcessStop(Activity activity, Message message, TaskStatus? status)
        {
            if (activity != null)
            {
               
            }
        }

        #endregion


        #region ProcessSession

        internal Activity ProcessSessionStart(IMessageSession session, Message message)
        {
            return ProcessStart("ProcessSession", message, () => new
                {
                    Session = session,
                    Message = message,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetTags(a, message));
        }

        internal void ProcessSessionStop(Activity activity, IMessageSession session, Message message, TaskStatus? status)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region Schedule

        internal Activity ScheduleStart(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            Activity activity = Start("Schedule", () => new
                {
                    Message = message,
                    ScheduleEnqueueTimeUtc = scheduleEnqueueTimeUtc,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetTags(a, message));

            Inject(message);

            return activity;
        }

        internal void ScheduleStop(Activity activity, Message message, DateTimeOffset scheduleEnqueueTimeUtc, TaskStatus? status, long sequenceNumber)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region Cancel

        internal Activity CancelStart(long sequenceNumber)
        {
            return Start("Cancel", () => new
            {
                SequenceNumber = sequenceNumber,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void CancelStop(Activity activity, long sequenceNumber, TaskStatus? status)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region Receive

        internal Activity ReceiveStart(int messageCount)
        {
            return Start("Receive", () => new
            {
                RequestedMessageCount = messageCount,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void ReceiveStop(Activity activity, int messageCount, TaskStatus? status, IList<Message> messageList)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region Peek

        internal Activity PeekStart(long fromSequenceNumber, int messageCount)
        {
            return Start("Peek", () => new
            {
                FromSequenceNumber = fromSequenceNumber,
                RequestedMessageCount = messageCount,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void PeekStop(Activity activity, long fromSequenceNumber, int messageCount, TaskStatus? status, IList<Message> messageList)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region ReceiveDeferred

        internal Activity ReceiveDeferredStart(IEnumerable<long> sequenceNumbers)
        {
            return Start("ReceiveDeferred", () => new
            {
                SequenceNumbers = sequenceNumbers,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void ReceiveDeferredStop(Activity activity, IEnumerable<long> sequenceNumbers, TaskStatus? status, IList<Message> messageList)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region  Complete

        internal Activity CompleteStart(IList<string> lockTokens)
        {
            return Start("Complete", () => new
            {
                LockTokens = lockTokens,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void CompleteStop(Activity activity, IList<string> lockTokens, TaskStatus? status)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region Dispose

        internal Activity DisposeStart(string operationName, string lockToken)
        {
            return Start(operationName, () => new
            {
                LockToken = lockToken,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void DisposeStop(Activity activity, string lockToken, TaskStatus? status)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion

 
        #region RenewLock

        internal Activity RenewLockStart(string lockToken)
        {
            return Start("RenewLock", () => new
            {
                LockToken = lockToken,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void RenewLockStop(Activity activity, string lockToken, TaskStatus? status, DateTime lockedUntilUtc)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region AddRule

        internal Activity AddRuleStart(RuleDescription description)
        {
            return Start("AddRule", () => new
            {
                Rule = description,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void AddRuleStop(Activity activity, RuleDescription description, TaskStatus? status)
        {
            if (activity != null)
            {

            }
        }

        #endregion


        #region RemoveRule

        internal Activity RemoveRuleStart(string ruleName)
        {
            return Start("RemoveRule", () => new
            {
                RuleName = ruleName,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void RemoveRuleStop(Activity activity, string ruleName, TaskStatus? status)
        {
            if (activity != null)
            {
                
            }
        }

        #endregion


        #region GetRules

        internal Activity GetRulesStart()
        {
            return Start("GetRules", () => new
            {
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void GetRulesStop(Activity activity, IEnumerable<RuleDescription> rules, TaskStatus? status)
        {
            if (activity != null)
            {

            }
        }

        #endregion


        #region AcceptMessageSession

        internal Activity AcceptMessageSessionStart(string sessionId)
        {
            return Start("AcceptMessageSession", () => new
                {
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetSessionTag(a, sessionId)
            );
        }

        internal void AcceptMessageSessionStop(Activity activity, string sessionId, TaskStatus? status)
        {
            if (activity != null)
            {

            }
        }

        #endregion


        #region GetSessionStateAsync

        internal Activity GetSessionStateStart(string sessionId)
        {
            return Start("GetSessionState", () => new
                {
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetSessionTag(a, sessionId));
        }

        internal void GetSessionStateStop(Activity activity, string sessionId, byte[] state, TaskStatus? status)
        {
            if (activity != null)
            {
  
            }
        }

        #endregion


        #region SetSessionState

        internal Activity SetSessionStateStart(string sessionId, byte[] state)
        {
            return Start("SetSessionState", () => new
                {
                    State = state,
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetSessionTag(a, sessionId));
        }

        internal void SetSessionStateStop(Activity activity, byte[] state, string sessionId, TaskStatus? status)
        {
            if (activity != null)
            {
  
            }
        }

        #endregion


        #region RenewSessionLock

        internal Activity RenewSessionLockStart(string sessionId)
        {
            return Start("RenewSessionLock", () => new
            {
                SessionId = sessionId,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            a => SetSessionTag(a, sessionId));
        }

        internal void RenewSessionLockStop(Activity activity, string sessionId, TaskStatus? status)
        {
            if (activity != null)
            {

            }
        }

        #endregion

        internal void ReportException(Exception ex)
        {
            
        }

        private Activity Start(string operationName, Func<object> getPayload, Action<Activity> setTags)
        {
            Activity activity = null;
            string activityName = BaseActivityName + operationName;
            

            return activity;
        }

        private void Inject(IList<Message> messageList)
        {
            
        }

        private void Inject(Message message)
        {
            
        }

        private void Inject(Message message, string id, string correlationContext)
        {
            if (message != null && !message.UserProperties.ContainsKey(ActivityIdPropertyName))
            {
                message.UserProperties[ActivityIdPropertyName] = id;
                if (correlationContext != null)
                {
                    message.UserProperties[CorrelationContextPropertyName] = correlationContext;
                }
            }
        }

        private string SerializeCorrelationContext(IList<KeyValuePair<string,string>> baggage)
        {
            if (baggage != null && baggage.Count > 0)
            {
                return string.Join(",", baggage.Select(kvp => kvp.Key + "=" + kvp.Value));
            }
            return null;
        }

        private void SetRelatedOperations(Activity activity, IList<Message> messageList)
        {
            if (messageList != null && messageList.Count > 0)
            {
                var relatedTo = new List<string>();
                foreach (var message in messageList)
                {
                    if (message.TryExtractId(out string id))
                    {
                        relatedTo.Add(id);
                    }
                }
            }
        }

        private Activity ProcessStart(string operationName, Message message, Func<object> getPayload, Action<Activity> setTags)
        {
            Activity activity = null;
            string activityName = BaseActivityName + operationName;

            
            return activity;
        }

        private void SetTags(Activity activity, IList<Message> messageList)
        {
            if (messageList == null)
            {
                return;
            }

           
        }

        private void SetTags(Activity activity, Message message)
        {
            if (message == null)
            {
                return;
            }


            SetSessionTag(activity, message.SessionId);
        }

        private void SetSessionTag(Activity activity, string sessionId)
        {
           
        }
    }
}