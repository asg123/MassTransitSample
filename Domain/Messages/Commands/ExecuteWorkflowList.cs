using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Messages.Commands
{

    public class ExecuteWorkflowList
    {
        public Guid BatchId { get; set; }
        public IEnumerable<WorkflowExecution> WorkflowList;
    }

    public class WorkflowExecution
    {
        public string WorkflowId { get; set; }
        public IEnumerable<WorkflowParameter> Parameters { get; set; }
    }

    public class WorkflowParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

}
