using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VideoGamesWebAPIProject.BusinessLogic;
using VideoGamesWebAPIProject.Models;

namespace VideoGamesWebAPIProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGamesManager _manager;

        public VideoGamesController(VideoGamesManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// GET: api/VideoGamesController/All
        /// Получить список объектов "VideoGame"
        /// </summary>
        /// <returns>Возвращает статус выполнения,
        /// в случае успешности возвращает список объектов "VideoGame"</returns>
        [HttpGet]
        public ActionResult All()
        {
            var result = _manager.GetVideoGamesList();
            if (result.Count() == 0 )
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// GET: api/VideoGamesController/GetById/{"id"}
        /// Получить объект "VideoGame" по Id
        /// </summary>
        /// <param name="id">id искомой игры </param>
        /// <returns>Возвращает статус выполнения,
        /// в случае успешности возвращает и объект "VideoGame"</returns>
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _manager.GetVideoGameById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// GET: api/VideoGamesController/GetByFilter
        /// Получить список объектов "VideoGame"
        /// </summary>
        /// <param name="filter">Объект содержащий условия фильтрации</param>
        /// <returns>Возвращает статус выполнения, в случае успешности возвращает
        /// список объектов "VideoGame" удовлетворяющих условиям фильтрации</returns>
        [HttpGet]
        public ActionResult GetByFilter(VideoGamesFilterQueryOptions filter)
        {
            var validationAnswerResault = IsValid();
            if (validationAnswerResault == null)
            {
                var videoGamesList = _manager.GetGamesWithFilter(filter);
                if (videoGamesList.Count() > 0)
                { 
                    return Ok(videoGamesList);
                }

                return NotFound();
            }

            return validationAnswerResault;
        }

        /// <summary>
        /// PUT: api/VideoGamesController/Update
        /// Обновить запись
        /// </summary>
        /// <param name="videoGame">Данные объекта которые должны обновиться обновить</param>
        /// <returns>Возвращает статус выполнения</returns>
        [HttpPut]
        public ActionResult Update(VideoGame videoGame)
        {
            var validationAnswerResault = IsValid();
            if (validationAnswerResault == null)
            {
                var status = _manager.EditVIdeoGame(videoGame);
                if (status.Equals("Not Found!"))
                {
                    return Ok(status);
                }

                return NotFound(status);
            }

            return validationAnswerResault;
        }

        /// <summary>
        /// POST: api/VideoGamesController/Add
        /// Добавить новую запись
        /// </summary>
        /// <param name="videoGame">Данные нового объекта</param>
        /// <returns>Возвращает статус выполнения операции</returns>
        [HttpPost]
        public ActionResult Add(VideoGame videoGame)
        {
            var response = IsValid() ?? Ok(_manager.AddVideoGame(videoGame));

            return response;
        }

        /// <summary>
        /// DELETE: api/VideoGamesController/Delete/{"id"}
        /// Удалить запись
        /// </summary>
        /// <param name="id">Id удаляемой записи</param>
        /// <returns>Возвращает статус выполнения</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var status = _manager.DeleteVideoGame(id);
            if (status.Equals("Not Found!"))
            {
                return NotFound(status);
            }

            return Ok(status);
        }

        /// <summary>
        /// Проверить валидность модели
        /// </summary>
        /// <returns>В случае валидности модели возвращает null, иначе возвращает список ошибок</returns>
        private ActionResult IsValid()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors, (y, z) => z.Exception.Message);

                return BadRequest(errors);
            }

            return null;
        }
    }
}
