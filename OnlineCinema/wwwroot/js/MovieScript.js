import { getResponseJson } from './JavaScript.js'

const seriesList = document.querySelector('.series-list')

getResponseJson().then(data => {
    const listElement = document.createElement('li')

    listElement.innerHTML(`<h4>${data.title}</h4>`)
    seriesList.appendChild(listElement)
})
