import {getResponseJson} from './JavaScript.js'
 
/*getResponseJson('Home/GetMedia?order=by_view').then(data => console.log(data))
getResponseJson('Home/GetMedia?order=popular').then(data => console.log(data))
getResponseJson('Home/GetMedia?order=latest_episode').then(data => console.log(data))
getResponseJson('Home/GetMedia?order=by_year').then(data => console.log(data))*/

getResponseJson('Media/GetMedia').then(data => {


    data.forEach(x => {
        const img = document.createElement('img')
        const title = document.createElement('h3')
        const detailLink = document.createElement('a')

        detailLink.href = `Media/Details?seasonId=${x.id}`
        detailLink.textContent = 'Detail'
        let imgPath = x.posterUrl.replaceAll('\\', '/')
        img.src = imgPath
        title.textContent = x.title

        document.body.appendChild(img)
        document.body.appendChild(title)
        document.body.appendChild(detailLink)
    })
  
})

getResponseJson('Media/GetMedia').then(data => {

    for (var i = 0; i < data.length; i++) {
        console.log(data[i])
    }
})
