using System.Text;
using System.Text.RegularExpressions;

internal static class Program
{
    private const int DefaultOctave = 4;

    private const string Pause = "P";

    private static readonly string[] Notes =
    {
        "A#",
        "B#",
        "C#",
        "D#",
        "E#",
        "F#",
        "G#",
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        Pause,
    };

    private static readonly Regex numberRx = new Regex("^[0-9]+");

    private static readonly string[] Blheli32 =
    {
        "C4 8 P8 C4 4 C5 4 C4 8 P8 C4 4 A#4 4 C4 8 P8 C4 4 G#4 4 C4 8 P8 C4 4 F#4 4 C4 8 P 8 C4 4 G4 4 G#4 4 C4 8 P8 C4 4 C5 4 C4 8 P8 C4 4 A#4 4 C4 8 P8 C4 4 G#4 4 C4 8 P8 C4 4 F#4 1",
        "C4 8 P8 C4 4 C5 4 C4 8 P8 C4 4 A#4 4 C4 8 P8 C4 4 G#4 4 C4 8 P8 C4 4 F#4 4 C4 8 P 8 C4 4 G4 4 G#4 4 C4 8 P8 C4 4 C5 4 C4 8 P8 C4 4 A#4 4 C4 8 P8 C4 4 G#4 4 C4 8 P8 C4 4 C4 1",
        "C4 4 P4 C4 4 P4 C4 4 P4 C4 4 P4 C4 4 P4 C4 4 P4 C4 4 C4 2 P4 C4 4 P2 P4 C4 4 P2 P4 C4 4 P4 C4 4 C4 1",
        "C5 8 P8 C5 4 C6 4 C5 8 P8 C5 4 A#5 4 C5 8 P8 C5 4 G#5 4 C5 8 P8 C5 4 F#5 4 C5 8 P 8 C5 4 G5 4 G#5 4 C5 8 P8 C5 4 C6 4 C5 8 P8 C5 4 A#5 4 C5 8 P8 C5 4 G#5 4 C5 8 P8 C5 4 F#4 1",
    };

    [STAThread]
    private static void Main()
    {
        do
        {
            foreach (var melody in Blheli32)
            {
                var rtttl = GetRtttl(melody);
                Log.Info(rtttl);
            }

        } while (false);

        Log.Info("Done.");
    }

    private static string GetNumber(out int number, string melody)
    {
        number = -1;

        Match m = numberRx.Match(melody);
        if (m.Groups.Count != 1)
        {
            throw new Exception("Parsing error.");
        }

        string g = m.Groups[0].ToString();
        number = int.Parse(g);
        melody = melody[g.Length..];
        return melody;
    }

    private static string GetRtttl(string melody)
    {
        var sb = new StringBuilder();
        melody = melody.Replace(" ", "");
        while (melody.Length > 0)
        {
            foreach (var note in Notes)
            {
                if (melody.StartsWith(note))
                {
                    melody = melody[note.Length..];
                    if (note == Pause)
                    {
                        melody = GetNumber(out int pauseDuration, melody);
                        sb.Append(pauseDuration).Append(Pause.ToLower()).Append(',');
                        break;
                    }

                    int octave = int.Parse(melody[..1]);
                    melody = melody[1..];
                    melody = GetNumber(out int noteDuration, melody);
                    sb.Append(noteDuration).Append(note.ToLower()).Append(octave).Append(',');
                    break;
                }
            }
        }
        return sb.ToString()[..^1]; // Remove ending ','
    }
}