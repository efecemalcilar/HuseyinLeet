using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Bll.Services.TranslationLogService.Abstract;
using Translator.Dal.Repositories.Abstract;
using Translator.Dto.Request;
using Translator.Dto.Response;
using Translator.Entity;

namespace Translator.Bll.Services.TranslationLogService.Concrete
{
    public class TranslationLogServices : ITranslationLogServices
    {
        ITranslationLogRepository _translationLogRepository;

        public TranslationLogServices(ITranslationLogRepository translationLogRepository)
        {
            _translationLogRepository = translationLogRepository;
        }
        public BaseResponseDto AddTranslationData(AddTranslationDataRequestDto request)
        {
            try
            {
                TranslationLog entity = new TranslationLog { Text = request.Text, Translation = request.Translation, TranslationType = request.TranslationType, CreatedAt = DateTime.Now };

                _translationLogRepository.Insert(entity);

                return new BaseResponseDto { StatusCode = 201, Message = "Success" };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while recording TranslationData\n Reason: {ex.Message}");
            }
        }

        public BaseResponseWithDataDto<List<TranslationLogDto>> GetTranslationLogs(TranslationLogFilterRequestDto filter)
        {
            try
            {
                List<TranslationLogDto> translationList = new List<TranslationLogDto>();

                var translationHistoryList = _translationLogRepository.GetAll();

                translationHistoryList = filter.MinDate == DateTime.MinValue ? translationHistoryList : translationHistoryList.Where(x => x.CreatedAt >= filter.MinDate).ToList();
                translationHistoryList = filter.MaxDate == DateTime.MaxValue ? translationHistoryList : translationHistoryList.Where(x => x.CreatedAt <= filter.MinDate).ToList();
                translationHistoryList = filter.Text == "" || filter.Text == null ? translationHistoryList : translationHistoryList.Where(x => x.Text.ToLower().Contains(filter.Text.ToLower())).ToList();
                translationHistoryList = filter.Translation == "" || filter.Translation == null ? translationHistoryList : translationHistoryList.Where(x => x.Translation.ToLower().Contains(filter.Translation.ToLower())).ToList();
                translationHistoryList = filter.TranslationType == "" || filter.TranslationType == null ? translationHistoryList : translationHistoryList.Where(x => x.TranslationType.ToLower().Contains(filter.TranslationType.ToLower())).ToList();


                foreach (var translation in translationHistoryList)
                {
                    translationList.Add(new TranslationLogDto
                    {
                        Id = translation.Id,
                        Text = translation.Text,
                        Translation = translation.Translation,
                        TranslationType = translation.TranslationType,
                        CreatedAt = translation.CreatedAt
                    });
                }
                return new BaseResponseWithDataDto<List<TranslationLogDto>>()
                {
                    Data = translationList,
                    StatusCode = 200,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving translations TranslationData\n Reason: {ex.Message}");
            }
        }
    }
}
