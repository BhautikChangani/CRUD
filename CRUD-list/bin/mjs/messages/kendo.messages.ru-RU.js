/**
 * Kendo UI v2024.2.514 (http://www.telerik.com/kendo-ui)
 * Copyright 2024 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"../kendo.core.js";!function(e,t){kendo.ui.FilterCell&&(kendo.ui.FilterCell.prototype.options.operators=e.extend(!0,kendo.ui.FilterCell.prototype.options.operators,{date:{eq:"равна",gte:"после или равна",gt:"после",lte:"до или равна",lt:"до",neq:"не равна"},number:{eq:"равно",gte:"больше или равно",gt:"больше",lte:"меньше или равно",lt:"меньше",neq:"не равно"},string:{endswith:"оканчивается на",eq:"равно",neq:"не равно",startswith:"начинающимися на",contains:"содержащими",doesnotcontain:"не содержит"},enums:{eq:"равно",neq:"не равно"}})),kendo.ui.FilterMenu&&(kendo.ui.FilterMenu.prototype.options.operators=e.extend(!0,kendo.ui.FilterMenu.prototype.options.operators,{date:{eq:"равна",gte:"после или равна",gt:"после",lte:"до или равна",lt:"до",neq:"не равна"},number:{eq:"равно",gte:"больше или равно",gt:"больше",lte:"меньше или равно",lt:"меньше",neq:"не равно"},string:{endswith:"оканчивается на",eq:"равно",neq:"не равно",startswith:"начинающимися на",contains:"содержащими",doesnotcontain:"не содержит"},enums:{eq:"равно",neq:"не равно"}})),kendo.ui.ColumnMenu&&(kendo.ui.ColumnMenu.prototype.options.messages=e.extend(!0,kendo.ui.ColumnMenu.prototype.options.messages,{columns:"Столбцы",sortAscending:"Сортировка по возрастанию",sortDescending:"Сортировка по убыванию",settings:"Параметры столбцов",done:"Готово",lock:"Заблокировать",unlock:"Разблокировать",filter:"Фильтровать"})),kendo.ui.DateRangePicker&&(kendo.ui.DateRangePicker.prototype.options.messages=e.extend(!0,kendo.ui.DateRangePicker.prototype.options.messages,{startLabel:"Начало",endLabel:"Конец"})),kendo.ui.RecurrenceEditor&&(kendo.ui.RecurrenceEditor.prototype.options.messages=e.extend(!0,kendo.ui.RecurrenceEditor.prototype.options.messages,{daily:{interval:"дней",repeatEvery:"Повторять каждые:"},end:{after:"После",occurrence:"входит",label:"Конец:",never:"Никогда",on:"В",mobileLabel:"Окончание"},frequencies:{daily:"Ежедневно",monthly:"Ежемесячно",never:"Никогда",weekly:"Еженедельно",yearly:"Ежегодно"},monthly:{day:"День",interval:"месяцы",repeatEvery:"Повторять каждый:",repeatOn:"Повторение:"},offsetPositions:{first:"первый",fourth:"четвертый",last:"последний",second:"второй",third:"третий"},weekly:{repeatEvery:"Повторять каждую:",repeatOn:"Повторение:",interval:"неделя"},yearly:{of:"из",repeatEvery:"Повторять каждый:",repeatOn:"Повторение:",interval:"годы"},weekdays:{day:"день",weekday:"будний",weekend:"выходной"}})),kendo.ui.Grid&&(kendo.ui.Grid.prototype.options.messages=e.extend(!0,kendo.ui.Grid.prototype.options.messages,{commands:{create:"Добавить",destroy:"Удалить",canceledit:"Отмена",update:"Обновить",edit:"Изменить",excel:"Экспорт в Excel",pdf:"Экспорт в PDF",select:"Выбрать",cancel:"Отменить изменения",save:"Сохранить изменения"},editable:{confirmation:"Вы уверены, что хотите удалить эту запись?",cancelDelete:"Отмена",confirmDelete:"Удалить"},noRecords:"Нет доступных записей."})),kendo.ui.Pager&&(kendo.ui.Pager.prototype.options.messages=e.extend(!0,kendo.ui.Pager.prototype.options.messages,{allPages:"Все",page:"Страница",display:"Отображены записи {0} - {1} из {2}",of:"из {0}",empty:"Нет записей для отображения",refresh:"Обновить",first:"Вернуться на первую страницу",itemsPerPage:"элементов на странице",last:"К последней странице",next:"Перейдите на следующую страницу",previous:"Перейти на предыдущую страницу",morePages:"Больше страниц"})),kendo.ui.TreeList&&(kendo.ui.TreeList.prototype.options.messages=e.extend(!0,kendo.ui.TreeList.prototype.options.messages,{noRows:"Нет записей доступны.",loading:"Loading...",requestFailed:"Request failed.",retry:"Retry",commands:{edit:"Изменить",update:"Обновить",canceledit:"Отмена",create:"Добавить",createchild:"Добавить ребенка",destroy:"Удалить",excel:"Экспорт в Excel",pdf:"Экспорт в PDF"}})),kendo.ui.TreeListPager&&(kendo.ui.TreeListPager.prototype.options.messages=e.extend(!0,kendo.ui.TreeListPager.prototype.options.messages,{allPages:"Все",page:"Страница",display:"Отображены записи {0} - {1} из {2}",of:"из {0}",empty:"Нет записей для отображения",refresh:"Обновить",first:"Вернуться на первую страницу",itemsPerPage:"элементов на странице",last:"К последней странице",next:"Перейдите на следующую страницу",previous:"Перейти на предыдущую страницу",morePages:"Больше страниц"})),kendo.ui.FilterCell&&(kendo.ui.FilterCell.prototype.options.messages=e.extend(!0,kendo.ui.FilterCell.prototype.options.messages,{filter:"фильтровать",clear:"очистить",isFalse:"ложь",isTrue:"истина",operator:"Оператор"})),kendo.ui.FilterMenu&&(kendo.ui.FilterMenu.prototype.options.messages=e.extend(!0,kendo.ui.FilterMenu.prototype.options.messages,{filter:"фильтровать",and:"И",clear:"очистить",info:"Строки со значениями",title:"Строки со значениями",selectValue:"-выберите-",isFalse:"ложь",isTrue:"истина",or:"или",cancel:"Отмена",operator:"Оператор",value:"Значение"})),kendo.ui.FilterMultiCheck&&(kendo.ui.FilterMultiCheck.prototype.options.messages=e.extend(!0,kendo.ui.FilterMultiCheck.prototype.options.messages,{search:"Поиск"})),kendo.ui.Groupable&&(kendo.ui.Groupable.prototype.options.messages=e.extend(!0,kendo.ui.Groupable.prototype.options.messages,{empty:"Переместите сюда заголовок столбца, чтобы сгруппировать записи по этому столбцу"})),kendo.ui.Editor&&(kendo.ui.Editor.prototype.options.messages=e.extend(!0,kendo.ui.Editor.prototype.options.messages,{bold:"Полужирный",cleanFormatting:"Очистить формат",createLink:"Вставить гиперссылку",fontName:"Шрифт",fontNameInherit:"(шрифт как в документе)",fontSize:"Выбрать размер шрифта",fontSizeInherit:"(размер как в документе)",formatBlock:"Текст изображения",indent:"Увеличить отступ",insertHtml:"Вставить HTML",insertImage:"Изображение",insertOrderedList:"Нумерованный список",insertUnorderedList:"Маркированный список",italic:"Курсив",justifyCenter:"По центру",justifyFull:"По ширине",justifyLeft:"Влево",justifyRight:"Вправо",outdent:"Уменьшить отступ",strikethrough:"Зачеркнутый",style:"Стиль",subscript:"Под строкой",superscript:"Над строкой",underline:"Подчеркнутый",unlink:"Удалить гиперссылку",dialogButtonSeparator:"или",dialogCancel:"Отмена",dialogInsert:"Вставить",imageAltText:"Альтернативный текст",imageWebAddress:"Веб адрес",linkOpenInNewWindow:"Открыть в новом окне",linkText:"Текст",linkToolTip:"Всплывающая подсказка",linkWebAddress:"Веб адрес",search:"Поиск",createTable:"Вставить таблицу",addColumnLeft:"Добавить столбец слева",addColumnRight:"Добавить столбец справа",addRowAbove:"Добавить строку выше",addRowBelow:"Добавить строку ниже",deleteColumn:"Удалить столбец",deleteRow:"Удалить строку",backColor:"Цвет фона",deleteFile:'Вы уверены, что хотите удалить "{0}"?',directoryNotFound:"Каталог с таким именем не найден.",dropFilesHere:"для загрузки перетащите файлы сюда",emptyFolder:"Пустая папка",foreColor:"Цвет",invalidFileType:'Выбранный файл "{0}" не верен. Поддерживаемые типы файлов {1}.',orderBy:"Упорядочить по:",orderByName:"Имя",orderBySize:"Размер",overwriteFile:'\'Файл с именем "{0}" уже существует в этой папке. Вы хотите перезаписать его?',uploadFile:"Загрузить",formatting:"Формат",viewHtml:"Просмотр HTML",dialogUpdate:"Обновить",insertFile:"Вставить файл"})),kendo.ui.Upload&&(kendo.ui.Upload.prototype.options.localization=e.extend(!0,kendo.ui.Upload.prototype.options.localization,{cancel:"Отменить загрузку",dropFilesHere:"перетащите сюда файлы для загрузки",remove:"Удалить",retry:"Повторить",select:"Выбрать...",statusFailed:"загрузка прервана",statusUploaded:"загружено",statusUploading:"загружается",uploadSelectedFiles:"Загрузить выбранные файлы",headerStatusUploaded:"Готово",headerStatusUploading:"Загружается..."})),kendo.ui.Scheduler&&(kendo.ui.Scheduler.prototype.options.messages=e.extend(!0,kendo.ui.Scheduler.prototype.options.messages,{allDay:"весь день",cancel:"Отмена",editable:{confirmation:"Вы уверены, что хотите удалить это событие?"},date:"Дата",destroy:"Удалить",editor:{allDayEvent:"Событие на весь день",description:"Описание",editorTitle:"Событие",end:"Окончание",endTimezone:"Часовой пояс окончания",repeat:"Повторение",separateTimezones:"Для начала и окончания используйте свой часовой пояс",start:"Начало",startTimezone:"Часовой пояс начала",timezone:" ",timezoneEditorButton:"Часовой пояс",timezoneEditorTitle:"Часовые пояса",title:"Заголовок",noTimezone:"Без часового пояса"},event:"Событие",recurrenceMessages:{deleteRecurring:"Вы хотите удалить только это событие или весь ряд повторяющихся событий?",deleteWindowOccurrence:"Удалить это событие",deleteWindowSeries:"Удалить весь ряд",deleteWindowTitle:"Удалить повторяющееся событие",editRecurring:"Вы хотите внести изменение только в это событие или изменить весь ряд?",editWindowOccurrence:"Изменить текущее событие",editWindowSeries:"Изменить весь ряд",editWindowTitle:"Изменить одно событие"},save:"Сохранить",time:"время",today:"Сегодня",views:{agenda:"Повестка",day:"День",month:"Месяц",week:"Неделя",workWeek:"Рабочая неделя"},deleteWindowTitle:"Удалить событие",showFullDay:"Показывать весь день",showWorkDay:"Показывать только рабочие часы"})),kendo.ui.Validator&&(kendo.ui.Validator.prototype.options.messages=e.extend(!0,kendo.ui.Validator.prototype.options.messages,{required:"{0} обязателен",pattern:"{0} не верен",min:"{0} должен быть больше или равен {1}",max:"{0} должен быть меньше или равен {1}",step:"{0} не верен",email:"{0} не корректный email",url:"{0} не корректный URL",date:"{0} не корректная дата"})),kendo.ui.Dialog&&(kendo.ui.Dialog.prototype.options.messages=e.extend(!0,kendo.ui.Dialog.prototype.options.localization,{close:"Закрыть"})),kendo.ui.Alert&&(kendo.ui.Alert.prototype.options.messages=e.extend(!0,kendo.ui.Alert.prototype.options.localization,{okText:"ОК"})),kendo.ui.Confirm&&(kendo.ui.Confirm.prototype.options.messages=e.extend(!0,kendo.ui.Confirm.prototype.options.localization,{okText:"ОК",cancel:"Отмена"})),kendo.ui.Prompt&&(kendo.ui.Prompt.prototype.options.messages=e.extend(!0,kendo.ui.Prompt.prototype.options.localization,{okText:"ОК",cancel:"Отмена"})),kendo.ui.DateInput&&(kendo.ui.DateInput.prototype.options.messages=e.extend(!0,kendo.ui.DateInput.prototype.options.messages,{year:"год",month:"месяц",day:"день",weekday:"день недели",hour:"час",minute:"минута",second:"секунда",dayperiod:"AM/PM"})),kendo.ui.PivotGrid&&(kendo.ui.PivotGrid.prototype.options.messages=e.extend(!0,kendo.ui.PivotGrid.prototype.options.messages,{measureFields:"Перетащите поля с данными сюда",columnFields:"Перетащите колонки сюда",rowFields:"Перетащите строки сюда"})),kendo.ui.PivotFieldMenu&&(kendo.ui.PivotFieldMenu.prototype.options.messages=e.extend(!0,kendo.ui.PivotFieldMenu.prototype.options.messages,{info:"Показать поля такие, что:",filterFields:"Фильтр по полям",filter:"Фильтровать",include:"Включить поля...",title:"Включить поля",clear:"Очистить",ok:"Ok",cancel:"Отмена",operators:{contains:"Содержит",doesnotcontain:"Не содержит",startswith:"Начинается с",endswith:"Заканчивается на",eq:"Равно",neq:"Не равно"}})),kendo.ui.Gantt&&(kendo.ui.Gantt.prototype.options.messages=e.extend(!0,kendo.ui.Gantt.prototype.options.messages,{actions:{addChild:"Добавить подзадачу",append:"Добавить задачу",insertAfter:"Добавить после",insertBefore:"Добавить до",pdf:"Экспорт в PDF"},cancel:"Отмена",deleteDependencyWindowTitle:"Удалить зависимость",deleteTaskWindowTitle:"Удалить задачу",destroy:"Удалить",editor:{assingButton:"Задать",editorTitle:"Задача",end:"Окончание",percentComplete:"Завершено",resources:"Ресурсы",resourcesEditorTitle:"Ресурсы",resourcesHeader:"Ресурсы",start:"Начало",title:"Название",unitsHeader:"Единицы"},save:"Сохранить",views:{day:"День",end:"Окончание",month:"Месяц",start:"Начало",week:"Неделя",year:"Год"}})),kendo.ui.Filter&&(kendo.ui.Filter.prototype.options.messages=e.extend(!0,kendo.ui.Filter.prototype.options.messages,{and:"И",or:"Или",apply:"Применить"})),kendo.ui.Filter&&(kendo.ui.Filter.prototype.options.operators=e.extend(!0,kendo.ui.Filter.prototype.options.operators,{date:{eq:"равна",gte:"после или равна",gt:"после",lte:"до или равна",lt:"до",neq:"не равна"},number:{eq:"равно",gte:"больше или равно",gt:"больше",lte:"меньше или равно",lt:"меньше",neq:"не равно"},string:{endswith:"оканчивается на",eq:"равно",neq:"не равно",startswith:"начинающимися на",contains:"содержащими",doesnotcontain:"не содержит"},enums:{eq:"равно",neq:"не равно"}})),kendo.spreadsheet&&kendo.spreadsheet.messages.borderPalette&&(kendo.spreadsheet.messages.borderPalette=e.extend(!0,kendo.spreadsheet.messages.borderPalette,{allBorders:"Все границы",insideBorders:"Внутри границ",insideHorizontalBorders:"Внутри горизонтальных границ",insideVerticalBorders:"Внутри вертикальных границ",outsideBorders:"За пределами границ",leftBorder:"Левая граница",topBorder:"Верхняя граница",rightBorder:"Правая граница",bottomBorder:"Нижняя граница",noBorders:"Без границ",reset:"Сбросить цвет",customColor:"Пользовательский цвет ...",apply:"Применять",cancel:"Отмена"})),kendo.spreadsheet&&kendo.spreadsheet.messages.dialogs&&(kendo.spreadsheet.messages.dialogs=e.extend(!0,kendo.spreadsheet.messages.dialogs,{apply:"Применять",save:"Сохранять",cancel:"Отмена",remove:"Удалять",retry:"Повторить",revert:"Возвращаться",okText:"В ПОРЯДКЕ",formatCellsDialog:{title:"Формат",categories:{number:"Число",currency:"Валюта",date:"Дата"}},fontFamilyDialog:{title:"Шрифт"},fontSizeDialog:{title:"Размер шрифта"},bordersDialog:{title:"Границы"},alignmentDialog:{title:"Выравнивание",buttons:{justifyLeft:"Выровнять по левому краю",justifyCenter:"Центр",justifyRight:"Выровнять по правому краю",justifyFull:"Оправдывать",alignTop:"Выровнять по верху",alignMiddle:"Выровнять по центру",alignBottom:"Выровнять по низу"}},mergeDialog:{title:"Объединить ячейки",buttons:{mergeCells:"Слить все",mergeHorizontally:"Слить по горизонтали",mergeVertically:"Слить по вертикали",unmerge:"Разъединить"}},freezeDialog:{title:"Замерзшие оконные стекла",buttons:{freezePanes:"Замерзшие оконные стекла",freezeRows:"Закрепить строки",freezeColumns:"Закрепить столбцы",unfreeze:"Разморозить стекла"}},confirmationDialog:{text:"Вы уверены, что хотите удалить этот лист?",title:"Удаление листа"},validationDialog:{title:"Проверка достоверности данных",hintMessage:"Введите допустимое {0} значение {1}.",hintTitle:"Проверка {0}",criteria:{any:"Любое значение",number:"Число",text:"Текст",date:"Дата",custom:"Пользовательская формула",list:"Список"},comparers:{greaterThan:"лучше чем",lessThan:"меньше, чем",between:"между",notBetween:"не между",equalTo:"равно",notEqualTo:"не равно",greaterThanOrEqualTo:"больше или равно",lessThanOrEqualTo:"меньше или равно"},comparerMessages:{greaterThan:"больше чем {0}",lessThan:"меньше чем {0}",between:"между {0} и {1}",notBetween:"не между {0} и {1}",equalTo:"равно {0}",notEqualTo:"не равно {0}",greaterThanOrEqualTo:"больше или равно {0}",lessThanOrEqualTo:"меньше или равно {0}",custom:"удовлетворяющий формуле: {0}"},labels:{criteria:"Критерии",comparer:"Сравнить",min:"Мин.",max:"Максимум",value:"Ценность",start:"Начинать",end:"Конец",onInvalidData:"О неверных данных",rejectInput:"Отклонить ввод",showWarning:"Показать предупреждение",showHint:"Показать подсказку",hintTitle:"Подсказка заголовка",hintMessage:"Подсказка",ignoreBlank:"Игнорировать пустое поле"},placeholders:{typeTitle:"Тип заголовка",typeMessage:"Введите сообщение"}},exportAsDialog:{title:"Экспорт ...",labels:{fileName:"Имя файла",saveAsType:"Сохранить как тип",exportArea:"Экспорт",paperSize:"Размер бумаги",margins:"Маржа",orientation:"Ориентация",print:"Распечатать",guidelines:"Методические рекомендации",center:"Центр",horizontally:"По горизонтали",vertically:"Вертикально"}},modifyMergedDialog:{errorMessage:"Невозможно изменить часть объединенной ячейки."},useKeyboardDialog:{title:"Копирование и вставка",errorMessage:"Эти действия нельзя вызвать через меню. Вместо этого используйте сочетания клавиш:",labels:{forCopy:"для копирования",forCut:"для резки",forPaste:"для пасты"}},unsupportedSelectionDialog:{errorMessage:"Это действие нельзя выполнить при множественном выборе."},insertCommentDialog:{title:"Вставить комментарий",labels:{comment:"Комментарий",removeComment:"Удалить комментарий"}},insertImageDialog:{title:"Вставить изображение",info:"Перетащите изображение сюда или щелкните, чтобы выбрать",typeError:"Выберите изображение в формате JPEG, PNG или GIF."}})),kendo.spreadsheet&&kendo.spreadsheet.messages.filterMenu&&(kendo.spreadsheet.messages.filterMenu=e.extend(!0,kendo.spreadsheet.messages.filterMenu,{sortAscending:"Сортировать по диапазону от А до Я",sortDescending:"Диапазон сортировки от Я до А",filterByValue:"Фильтр по значению",filterByCondition:"Фильтр по условию",apply:"Применять",search:"Поиск",addToCurrent:"Добавить к текущему выбору",clear:"Прозрачный",blanks:"(Пробелы)",operatorNone:"Никто",and:"И",or:"ИЛИ",operators:{string:{contains:"Текст содержит",doesnotcontain:"Текст не содержит",startswith:"Текст начинается с",endswith:"Текст заканчивается на"},date:{eq:"Дата",neq:"Дата не",lt:"Дата раньше",gt:"Дата после"},number:{eq:"Равно",neq:"Не равно",gte:"Больше или равно",gt:"Больше, чем",lte:"Меньше или равно",lt:"Меньше чем"}}})),kendo.spreadsheet&&kendo.spreadsheet.messages.colorPicker&&(kendo.spreadsheet.messages.colorPicker=e.extend(!0,kendo.spreadsheet.messages.colorPicker,{reset:"Сбросить цвет",customColor:"Пользовательский цвет ...",apply:"Применять",cancel:"Отмена"})),kendo.spreadsheet&&kendo.spreadsheet.messages.toolbar&&(kendo.spreadsheet.messages.toolbar=e.extend(!0,kendo.spreadsheet.messages.toolbar,{addColumnLeft:"Добавить столбец слева",addColumnRight:"Добавить столбец справа",addRowAbove:"Добавить строку выше",addRowBelow:"Добавить строку ниже",alignment:"Выравнивание",alignmentButtons:{justifyLeft:"Выровнять по левому краю",justifyCenter:"Центр",justifyRight:"Выровнять по правому краю",justifyFull:"Оправдывать",alignTop:"Выровнять по верху",alignMiddle:"Выровнять по центру",alignBottom:"Выровнять по низу"},backgroundColor:"Задний план",bold:"Смелый",borders:"Границы",colorPicker:{reset:"Сбросить цвет",customColor:"Пользовательский цвет ..."},copy:"Копировать",cut:"Резать",deleteColumn:"Удалить столбец",deleteRow:"Удалить строку",excelImport:"Импорт из Excel ...",filter:"Фильтр",fontFamily:"Шрифт",fontSize:"Размер шрифта",format:"Пользовательский формат ...",formatTypes:{automatic:"Автоматическая",number:"Число",percent:"Процентов",financial:"Финансовый",currency:"Валюта",date:"Дата",time:"Время",dateTime:"Дата время",duration:"Продолжительность",moreFormats:"Еще форматы ..."},formatDecreaseDecimal:"Уменьшить десятичный",formatIncreaseDecimal:"Увеличить десятичную дробь",freeze:"Замерзшие оконные стекла",freezeButtons:{freezePanes:"Замерзшие оконные стекла",freezeRows:"Закрепить строки",freezeColumns:"Закрепить столбцы",unfreeze:"Разморозить стекла"},insertComment:"Вставить комментарий",insertImage:"Вставить изображение",italic:"Курсив",merge:"Объединить ячейки",mergeButtons:{mergeCells:"Слить все",mergeHorizontally:"Слить по горизонтали",mergeVertically:"Слить по вертикали",unmerge:"Разъединить"},open:"Открытым...",paste:"Вставить",quickAccess:{redo:"Повторить",undo:"Отменить"},saveAs:"Сохранить как...",sortAsc:"Сортировать по возрастанию",sortDesc:"Сортировать по убыванию",sortButtons:{sortSheetAsc:"Сортировать лист от А до Я",sortSheetDesc:"Сортировать лист от Я до А",sortRangeAsc:"Сортировать по диапазону от А до Я",sortRangeDesc:"Диапазон сортировки от Я до А"},textColor:"Цвет текста",textWrap:"Перенести текст",underline:"Подчеркивание",validation:"Проверка достоверности данных..."})),kendo.spreadsheet&&kendo.spreadsheet.messages.view&&(kendo.spreadsheet.messages.view=e.extend(!0,kendo.spreadsheet.messages.view,{errors:{shiftingNonblankCells:"Не удается вставить ячейки из-за возможности потери данных. Выберите другое место для вставки или удалите данные с конца рабочего листа.",filterRangeContainingMerges:"Невозможно создать фильтр в диапазоне, содержащем слияния",validationError:"Введенное вами значение нарушает правила проверки, установленные для ячейки."},tabs:{home:"Домой",insert:"Вставлять",data:"Данные"}}))}(window.kendo.jQuery);
//# sourceMappingURL=kendo.messages.ru-RU.js.map
