import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { CarregarLivro } from './components/Livro/CarregarLivro';
import { SalvarLivro } from './components/Livro/SalvarLivro';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/carregarlivro' component={CarregarLivro} />
    <Route path='/salvarlivro' component={SalvarLivro} />
    <Route path='/livro/editar/:livroid' component={SalvarLivro} />
</Layout>;
