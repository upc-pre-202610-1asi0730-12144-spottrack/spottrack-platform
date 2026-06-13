using SpotTrack.Platform.Routines.Domain.Model.Commands;
using SpotTrack.Platform.Routines.Domain.Model.ValueObjects;

namespace SpotTrack.Platform.Routines.Domain.Model.Aggregates;

public partial class Routine
{
    public int Id { get; private set; }
    
    public RoutineName Name { get; private set; } = null!;
    
    public ClientId ClientId { get; private set; }

    public List<object> ExerciseBlocks { get; private set; } = new();
    
    private Routine(){ }

    public Routine(CreateRoutineCommand command)
    {
        Name = new RoutineName(command.RoutineName);
        ClientId = new ClientId(command.ClientId);
        ExerciseBlocks = new List<object>();
    }

}