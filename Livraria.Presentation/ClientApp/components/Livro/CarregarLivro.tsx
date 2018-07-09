import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface CarregarLivroDataState {
    title: string;
    livroLista: LivroData[];
    loading: boolean;
    showErro: boolean;
    erro: string;
}

export class CarregarLivro extends React.Component<RouteComponentProps<{}>, CarregarLivroDataState> {
    constructor() {
        super();
        this.state = { livroLista: [], loading: true, title: "Cadastro de Livros", showErro: false, erro: "" };

        fetch('Livro/Index', {
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                try {
                    this.setState({ livroLista: JSON.parse(data), loading: false, showErro: false });
                }
                catch (erro) {
                    throw data;
                }
            })
            .catch(erro => {
                this.setState({ loading: false, erro: erro, showErro: true });
            });

        // This binding is necessary to make "this" work in the callback
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Carregando...</em></p>
            : this.renderizarLivroTable(this.state.livroLista, this.state.showErro);

        return <div>
            <h1>{this.state.title}</h1>
            <hr />
            <p>
                <Link className="btn btn-primary" to="/salvarlivro">Novo</Link>
            </p>
            <div className="panel-body" style={{ display: this.state.showErro ? 'block' : 'none' }}>
                <h5 className="text-danger" id="panelErro">{this.state.erro}</h5>
            </div>
            {contents}
        </div>;
    }

    // Handle Delete request
    private handleDelete(id: number) {
        if (!confirm("Tem certeza que deseja excluir esse livro?"))
            return;
        else {
            fetch('Livro/Deletar/' + id, {
                method: 'delete',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            })
                .then(response => response.json())
                .then(data => {
                    if (data !== 'true') {
                        this.setState({ erro: data, showErro: true });
                    }
                    else {
                        this.setState(
                            {
                                livroLista: this.state.livroLista.filter((rec) => {
                                    return (rec.id != id);
                                }),
                                showErro: false
                            });
                    }
                });
        }
    }

    private handleEdit(id: number) {
        this.props.history.push("/livro/editar/" + id);
    }

    // Returns the HTML table to the render() method.
    private renderizarLivroTable(livroLista: LivroData[], showErro: boolean) {
        if (livroLista.length === 0 && showErro) return;
        return (livroLista.length === 0)
            ? <div className="panel-body">
                <h5 className="text-info">Não existem livros cadastrados!</h5>
            </div>
            : <div className="panel panel-primary">
                <div className="panel-body">
                    <table className='table'>
                        <thead>
                            <tr>
                                <th></th>
                                <th>Código</th>
                                <th>Título</th>
                                <th>Autor</th>
                                <th>Editora</th>
                                <th>Quantidade</th>
                                <th>Ações</th>
                            </tr>
                        </thead>
                        <tbody>
                            {livroLista.map(l =>
                                <tr key={l.id}>
                                    <td></td>
                                    <td>{l.id}</td>
                                    <td>{l.titulo}</td>
                                    <td>{l.autor}</td>
                                    <td>{l.editora}</td>
                                    <td>{l.quantidadeExemplares}</td>
                                    <td>
                                        <a title="Editar" className="action btn btn-primary" onClick={(id) => this.handleEdit(l.id)}>
                                            <span className="glyphicon glyphicon-edit" aria-hidden="true"></span>
                                        </a>
                                        <a title="Deletar" className="action btn btn-danger" onClick={(id) => this.handleDelete(l.id)}>
                                            <span className="glyphicon glyphicon-remove"></span>
                                        </a>
                                    </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </div>;
    }
}

export class LivroData {
    id: number = 0;
    titulo: string = "";
    autor: string = "";
    editora: string = "";
    quantidadeExemplares: number = 0;
    genero: string = "";
    anoEdicao: number = 0;
} 