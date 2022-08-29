using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Xpand.Events.CodeGenerators {
    [Generator]
    public class XEventCodeGenerator : ISourceGenerator {
        
        public void Initialize(GeneratorInitializationContext context) {
        }

        public void Execute(GeneratorExecutionContext context) {

            var sourceBuilder = new StringBuilder();
            sourceBuilder.AppendLine("namespace Xpand.Events {");
            sourceBuilder.AppendLine("    public class CodeGenXEvent : BaseEvent<Event> {");
            sourceBuilder.AppendLine("        public void Invoke() {Console.WriteLine(\"Invoke\");}");
            sourceBuilder.AppendLine("    }");
            sourceBuilder.AppendLine("}");
            
            SourceText source = SourceText.From(sourceBuilder.ToString(), Encoding.UTF8);
            context.AddSource("CodeGenXEvent.cs", source);
        }
    }
}