import React from 'react';
import {Link, NavLink} from "react-router-dom";




function Tablebl({items}) {
    return (

        <div className='DayTasks'>
            <table className="table">
                <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Название Лекарства</th>
                    <th scope="col">Название ингредиента</th>
                    <th scope="col">Взаимодествие</th>
                    <th scope="col">Тип взаимодествия</th>
                </tr>
                </thead>
                <tbody>
                {items.map(act =>
                    <tr>
                        <td>{act.idInteraction}</td>
                        <td>{act.drugs.name}</td>
                        <td>{act.ingredients.name}</td>
                        <td>{act.interactionText}</td>
                        <td>{act.interactionTypeId === 1 ? 'Положительное' : 'Негативное'}</td>

                    </tr>
                )}
                </tbody>
            </table>

        </div>
    );
}

export default Tablebl;