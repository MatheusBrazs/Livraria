import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Sistema Livraria</h1>
            <p>Sistema para realizar o cadastro de livros, desenvolvido com as seguinte tecnologias:</p>
            <ul>
                <li><a href='https://get.asp.net/'>ASP.NET Core</a> e <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> para backend</li>
                <li><a href='https://facebook.github.io/react/'>React</a> e <a href='http://www.typescriptlang.org/'>TypeScript</a> para frontend</li>
                <li><a href='http://getbootstrap.com/'>Bootstrap</a> para layout e estilo</li>
                <li><a href='http://nunit.org/'>NUnit</a>, <a href='https://fluentassertions.com/'> Fluent Assertions</a> e <a href='http://nsubstitute.github.io/'> NSubstitute</a> para testes unitarios</li>
                <li>SQL Server para banco de dados e <a href='http://nunit.org/'>EF Core</a> para acesso a dados</li>
            </ul>
        </div>;
    }
}
