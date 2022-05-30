export async function getResponseJson(url) {
    const res = await fetch(url, {
        headers: {
            'Accept': 'application/json'
        }
    })

    return await res.json()
}