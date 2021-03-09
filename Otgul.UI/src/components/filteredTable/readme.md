```json
{
    columns: [
            {
              field: 'roleName', // атрибут объекта из массива tableData
              name: 'Роль',      // имя отображаемое в заголовке
              filtered: true     // требуется ли фильртация по этому отрибуту
            },
            {
              name: 'test',                       // имя отображаемое в заголовке
              render: (createElement, props) => { // рендер функция, в props передается 
                return createElement(             // объект из массива tableData
                  'div',                          // может быть обогащен другой нагрузкой
                  {
                    style: {
                      backgroundColor: 'red'
                    },
                    class: {
                      'inner-cell': true
                    }
                  },
                  props
                )
              }
            },
            {
              name: 'Действия',       // имя отображаемое в заголовке
              component: RowButtonSet // кастомный компонент в props которого будет передан
            }                         // объект из массива tableData (row)
          ]
}
```

