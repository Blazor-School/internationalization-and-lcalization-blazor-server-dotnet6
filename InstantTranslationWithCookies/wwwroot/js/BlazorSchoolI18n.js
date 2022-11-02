class BlazorSchoolI18n
{
    addCookies(key, value)
    {
        document.cookie = `${key}=${value}`;
    }
}

window.BlazorSchoolI18n = new BlazorSchoolI18n();