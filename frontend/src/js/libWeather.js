const backendBaseUrl = process.env.VUE_APP_API_URL

// Make GET request
async function WebClientSendGetRequest
(
    relativeUrl
)
{
    const response = await fetch(backendBaseUrl + relativeUrl, {
        method: 'GET'
    })

    if (!response.ok)
    {
        alert("Ошибка запроса к бекенду по методу GET: " + relativeUrl)
        return
    }

    return response
}

// Make POST request
async function WebClientSendPostRequest
(
    relativeUrl,
    request
)
{
    const response = await fetch(backendBaseUrl + relativeUrl, {
        method: 'POST',
        body: JSON.stringify(request),
        headers: { 'Content-Type': 'application/json' }
    })

    if (!response.ok)
    {
        alert("Ошибка запроса к бекенду по методу POST: " + relativeUrl)
        return
    }

    return response
}

export
{
    WebClientSendGetRequest,
    WebClientSendPostRequest
}