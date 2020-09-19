using CourseShop.Core.DAL;
using CourseShop.Core.Entities.Enums;
using CourseShop.Core.Entities.FSM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseShop.HelperApps.DataSeed
{
    public class SeedDefaultFSMData : SeedBase
    {
        public override string SeedMessage => "Seeding FSM data";

        public override void Seed(CourseContext context)
        {
            if (!context.FSMTransitions.Any())
            {
                // (p&q)|r -> p,q,r => FSMConditions
                var data = new[]
                {
                    new FSMTransition { ConditionSequence = "AccountIsConfirmed", FSMTransitionId = 1, OrderStatusIdFrom = 0, OrderStatusIdTo = 1 },
                    new FSMTransition { ConditionSequence = "PaymentIsProcessed", FSMTransitionId = 2, OrderStatusIdFrom = 1, OrderStatusIdTo = 2 },
                    new FSMTransition { ConditionSequence = "", FSMTransitionId = 3, OrderStatusIdFrom = 2, OrderStatusIdTo = 3 },
                };
                context.FSMTransitions.AddRange(data);

                context.Database.OpenConnection();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FSMTransitions ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FSMTransitions OFF");
                context.Database.CloseConnection();
            }

            if (!context.FSMConditions.Any())
            {
                var data = new[]
                {
                    new FSMCondition { ConditionName = "AccountIsConfirmed", ConditionTypeId = (int)FSMConditionType.AccountConfirmedCheck, FSMConditionId = 1, FSMTransitionId = 1 },
                    new FSMCondition { ConditionName = "PaymentIsProcessed", ConditionTypeId = (int)FSMConditionType.ProcessedPaymentCheck, FSMConditionId = 2, FSMTransitionId = 2 }
                };
                context.FSMConditions.AddRange(data);

                context.Database.OpenConnection();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FSMConditions ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FSMConditions OFF");
                context.Database.CloseConnection();
            }

            if (!context.FSMActions.Any())
            {
                var data = new[]
                {
                    new FSMAction { FSMActionId = 1, ActionTypeId = (int)FSMActionType.SendEmail, FSMTransitionId = 1 },
                    new FSMAction { FSMActionId = 2, ActionTypeId = (int)FSMActionType.SendEmail, FSMTransitionId = 2 },
                    new FSMAction { FSMActionId = 3, ActionTypeId = (int)FSMActionType.SendEmail, FSMTransitionId = 3 }
                };
                context.FSMActions.AddRange(data);

                context.Database.OpenConnection();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FSMActions ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FSMActions OFF");
                context.Database.CloseConnection();
            }
        }
    }
}
