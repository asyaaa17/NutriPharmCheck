import React from 'react';
import {Link, NavLink} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";
import Cookies from "js-cookie";




function MainPage() {
    const dispatch=useDispatch();
    const id=useSelector(state => state.reducerUser.access_token)
    console.log(id);
    const flag=Cookies.get('flag')
    console.log(flag)


    return (

        <div className='MainPage'>
            <div className="container">
                <h2>Сайт для поиска совместимости БАДа и лекарства
                </h2>
            </div>
        </div>
    );
}
export default MainPage;