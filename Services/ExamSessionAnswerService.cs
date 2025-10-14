using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Services
{
    public class ExamSessionAnswerService(IExamSessionAnswerRepository repository) : IExamSessionAnswerService
    {
        public async Task<bool> DeleteAsync(Guid id)
        {
            var selectedExamSessionAnswer = await repository.GetByIdAsync(id);
            if (selectedExamSessionAnswer == null) return false;

            await repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<ExamSessionAnswer>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<bool> UpdateAsync(Guid id, ExamSessionAnswer examSessionAnswer)
        {
            var selectedEntity = await repository.GetByIdAsync(id);
            if (selectedEntity == null) return false;

            selectedEntity.SelectedOptionIndex = examSessionAnswer.SelectedOptionIndex;

            await repository.UpdateAsync(selectedEntity);
            return true;
        }
    }
}