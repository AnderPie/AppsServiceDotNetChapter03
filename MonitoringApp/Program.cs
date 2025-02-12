using Packt.Shared;

WriteLine("Processing. Please wait...");
Recorder.Start();

/*
// simulate a process that requires some memory resources...
int[] largeArrayOfInts = Enumerable.Range(1, 10_000).ToArray();

// ...and takes some time to complete
Thread.Sleep(new Random().Next(5,10) * 1000);
Recorder.Stop();
*/

/* 
 * Demonstrate just how much more efficiently a StringBuilder is at adding a bunch of ',' to a large array string
 * compared to concatenating with a string's + operator overload
 */
int[] numbers = Enumerable.Range(1, 50_000).ToArray();
SectionTitle("Using StringBuilder");
Recorder.Start();

System.Text.StringBuilder builder = new();

for(int i = 0; i < numbers.Length; i++)
{
    builder.Append(numbers[i]);
    builder.Append(", ");
}

Recorder.Stop();
WriteLine();

SectionTitle("Using string with +");
Recorder.Start();

string s = string.Empty;

for(int i = 0; i < numbers.Length; i++)
{
    s += numbers[i] + ", ";
}
Recorder.Stop();

