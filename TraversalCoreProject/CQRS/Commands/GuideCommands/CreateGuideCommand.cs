using MediatR;

namespace TraversalCoreProject.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {
        public string GuideName { get; set; }
        public string Description { get; set; }
    }
}
