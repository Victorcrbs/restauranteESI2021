import { Button, Container, Stack, Typography, Grid } from '@mui/material';
import { Link as RouterLink } from 'react-router-dom';
import { Icon } from '@iconify/react';
import plusFill from '@iconify/icons-eva/plus-fill';
import minusFill from '@iconify/icons-eva/minus-fill';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import * as React from 'react';
import Page from '../components/Page';
// ----------------------------------------------------------------------

export default function Cardapio() {
  // eslint-disable-next-line global-require
  const axios = require('axios');
  let rows = [];

  axios
    .get('http://localhost:5000/api/pratos')
    .then((response) => {
      rows = response.data;
    })
    .catch((error) => {
      // handle error
      console.log(error);
    })
    .then(() => {
      // always executed
    });

  // add axios call
  // lembrar de quando pedir um prato mandar um request pra alterar o estoque de acordo com os ingredientes usados

  const imagemPratos = (prato) => {
    switch (prato) {
      case 'teste':
        return '/static/pratos/teste.jpg';
      case 'teste2':
        return '/static/pratos/teste2.jpg';
      case 'teste3':
        return '/static/pratos/teste3.jpg';
      case 'teste4':
        return '/static/pratos/teste4.jpg';
      case 'teste5':
        return '/static/pratos/teste5.jpg';
      case 'teste6':
        return '/static/pratos/teste6.jpg';
      case 'teste7':
        return '/static/pratos/teste7.jpg';
      case 'teste8':
        return '/static/pratos/teste8.jpg';
      case 'teste9':
        return '/static/pratos/teste9.jpg';
      case 'teste10':
        return '/static/pratos/teste10.jpg';
      default:
        return '/static/pratos/teste.jpg';
    }
  };

  const pratos = [
    {
      PratoId: 1,
      PratoNome: 'teste',
      PratoPreco: 1
    },
    {
      PratoId: 2,
      PratoNome: 'teste2',
      PratoPreco: 2
    },
    {
      PratoId: 3,
      PratoNome: 'teste3',
      PratoPreco: 3
    },
    {
      PratoId: 4,
      PratoNome: 'teste4',
      PratoPreco: 4
    },
    {
      PratoId: 5,
      PratoNome: 'teste5',
      PratoPreco: 5
    },
    {
      PratoId: 6,
      PratoNome: 'teste6',
      PratoPreco: 6
    },
    {
      PratoId: 7,
      PratoNome: 'teste7',
      PratoPreco: 7
    },
    {
      PratoId: 8,
      PratoNome: 'teste8',
      PratoPreco: 8
    },
    {
      PratoId: 9,
      PratoNome: 'teste9',
      PratoPreco: 9
    },
    {
      PratoId: 10,
      PratoNome: 'teste10',
      PratoPreco: 10
    }
  ];
  return (
    <Page title="Dashboard: Products | Minimal-UI">
      <Container>
        <Stack direction="row" alignItems="center" mb={5}>
          <Typography variant="h4" sx={{ mb: 5, paddingRight: '55%' }}>
            Cardápio
          </Typography>
          <Button
            variant="contained"
            component={RouterLink}
            to="#"
            startIcon={<Icon icon={plusFill} />}
          >
            Adicionar receita
          </Button>
          <Button
            variant="contained"
            component={RouterLink}
            to="#"
            startIcon={<Icon icon={minusFill} />}
            sx={{ marginLeft: 5 }}
          >
            Remover receita
          </Button>
        </Stack>
        <Grid container spacing={2} direction="row" justify="flex-start" alignItems="flex-start">
          {rows.map((prato) => (
            <Grid item xs={12} sm={6} md={3}>
              <Card sx={{ maxWidth: 345 }}>
                <CardMedia component="img" height="140" image={imagemPratos(prato.PratoNome)} />
                <CardContent>
                  <Typography gutterBottom variant="h5" component="div">
                    {prato.PratoNome}
                  </Typography>
                </CardContent>
                <CardActions>
                  <Button>Pedir</Button>
                </CardActions>
              </Card>
            </Grid>
          ))}
        </Grid>
      </Container>
    </Page>
  );
}
