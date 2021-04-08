namespace Mnemox.Machine.Metrics.Structures
{
    public class LinuxCommands
    {
        public const string GET_CPU_METRICS_FROM_TOP_COMMAND = "-c \"top -bn2 | fgrep 'Cpu(s)' | tail -1 \"";

        public const string GET_MEMORY_METRICS = "-c \"free -b\"";
    }
}
