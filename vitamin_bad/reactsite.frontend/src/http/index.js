import axios from 'axios';
import Cookies from "js-cookie";

export const Api_URL='http://localhost:7001'
const $api=axios.create(
    {
        withCredentials:true,
        baseURL:Api_URL
    }
)
$api.interceptors.request.use((config)=>{
    config.headers.Authorization= "Bearer "+ Cookies.get('access_token')
    return config;
})
export default $api;