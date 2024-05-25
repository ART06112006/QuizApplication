﻿using AutoMapper;
using Newtonsoft.Json;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace QuizApplication.Services
{
    public class APIQuestionService
    {
        private string categoriesUrl = "https://the-trivia-api.com/v2/categories";
        private string questionsUrl = "https://the-trivia-api.com/v2/questions";

        private readonly IMapper _mapper;

        public Action<string> ExceptionMessage { get; set; }

        public APIQuestionService(IMapper mapper) 
        { 
            _mapper = mapper;
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(categoriesUrl);

                    if (response != null)
                    {
                        var categories = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(response);

                        var categoryList = new List<string>();
                        foreach (var categoryGroup in categories.Values)
                        {
                            categoryList.AddRange(categoryGroup);
                        }

                        return categoryList;
                    }
                    else return null;
                }
            }
            catch (HttpRequestException ex)
            {
                ExceptionMessage?.Invoke($"Request error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                ExceptionMessage?.Invoke(ex.Message);
                return null;
            }
        }

        public async Task<Quiz> GetQuizAsync(string name, int questionLimit, List<string> difficultyLevels, List<string> categories)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var categoriesStr = string.Join(",", categories);
                    var difficultiesStr = string.Join(",", difficultyLevels);

                    var configuratedUrl = questionsUrl + $"?limit={questionLimit}&categories={categoriesStr}&difficulties={difficultiesStr}";

                    var response = await client.GetStringAsync(configuratedUrl);

                    if (response != null)
                    {
                        var questions = JsonConvert.DeserializeObject<List<APIQuestion>>(response);
                        var mappedQuestions = _mapper.Map<List<Question>>(questions);

                        return new Quiz()
                        {
                            Name = name,
                            IsFinished = false,
                            Questions = mappedQuestions,
                            TotalScore = 0,
                            UpdateDate = DateTime.Now
                        };
                    }
                    else return null;
                }
            }
            catch (HttpRequestException ex)
            {
                ExceptionMessage?.Invoke($"Request error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                ExceptionMessage?.Invoke(ex.Message);
                return null;
            }
        }
    }
}
