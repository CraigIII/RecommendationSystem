﻿
// This file was auto-generated by ML.NET Model Builder. 

using MLModel_ConsoleApp;

// Create single instance of sample data from first line of dataset for model input
MLModel.ModelInput sampleData = new MLModel.ModelInput()
{
    UserId = 1F,
    MovieId = 3F,
};

Console.WriteLine("Using model to make single prediction -- Comparing actual Rating with predicted Rating from sample data...\n\n");

Console.WriteLine($"UserId: {sampleData.UserId}");
Console.WriteLine($"MovieId: {sampleData.MovieId}");
//Console.WriteLine($"Rating: {4F}");

var predictionResult = MLModel.Predict(sampleData);
Console.WriteLine($"\n\nPredicted Rating: {predictionResult.Score}\n\n");

Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();
