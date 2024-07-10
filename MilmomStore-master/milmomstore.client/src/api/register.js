import baseUrl from "./api"

async function Register(data) {
    try {
        const Response = baseUrl.post('api/account/register', data)
        return (await Response).data;
    } catch (error) {
        console.log("Error")
    }
}