import React from 'react';
import {Link, NavLink} from "react-router-dom";
import Cookies from "js-cookie";
import {useSelector} from "react-redux";


/*Надо обновлять*/

function Navbar() {
    const stateflag=useSelector(state => state.reducerUser)
   const flag= Cookies.get('flag')
    console.log(flag)
        return <div className='Navbar ' className="p-3 mb-2 bg-black text-white">

            <ul className="nav nav-tabs">
                <div className="col-5">
                    <h2>NutriPharmCheck</h2>
                </div>

                <li className="nav-item">
                    <NavLink className="nav-link " aria-current="page" to='/'>Главная</NavLink>
                </li>

                <li className="nav-item">
                    <NavLink className="nav-link " to='/integration'>Совместимость</NavLink>
                </li>


                <li className="nav-item dropdown">
                    <a className="nav-link dropdown-toggle disabled" data-bs-toggle="dropdown" href="#" role="button"
                       aria-expanded="false">Активность</a>
                    <ul className="dropdown-menu">
                        <li className="nav-item "><NavLink className="dropdown-item" to='/dailytasks'>Мой день</NavLink>
                        </li>
                        <li className="nav-item"><NavLink className="dropdown-item" to='/weeklytasks'>Моя неделя</NavLink>
                        </li>
                        <li className="nav-item"><NavLink className="dropdown-item" to='/addplan'>Составить план</NavLink>
                        </li>
                    </ul>
                </li>



                        <li className="nav-item dropdown ">
                            <a className="nav-link dropdown-toggle disabled" data-bs-toggle="dropdown" href="#" role="button"
                               aria-expanded="false">Аккаунт</a>
                            <ul className="dropdown-menu">
                                <li className="nav-item"><NavLink className="dropdown-item" to='/signup'>Аккаунт</NavLink>
                                </li>
                                <li className="nav-item"><NavLink className="dropdown-item" to='/logout'>Выйти</NavLink>
                                </li>
                            </ul>
                        </li>


            </ul>
        </div>
}
export default Navbar;