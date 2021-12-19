import * as React from 'react';
import { Icon } from '@iconify/react';
import plusFill from '@iconify/icons-eva/plus-fill';
import { Link as RouterLink } from 'react-router-dom';
// material
import { Button, Container, Stack, Typography } from '@mui/material';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

// components
import Page from '../components/Page';

// ----------------------------------------------------------------------

export default function Estoque() {
  // add axios call

  const rows = [
    {
      IngredienteNome: 'a',
      IngredienteQuantidade: 1
    },
    {
      IngredienteNome: 'b',
      IngredienteQuantidade: 2
    },
    {
      IngredienteNome: 'c',
      IngredienteQuantidade: 3
    },
    {
      IngredienteNome: 'd',
      IngredienteQuantidade: 4
    },
    {
      IngredienteNome: 'e',
      IngredienteQuantidade: 5
    },
    {
      IngredienteNome: 'f',
      IngredienteQuantidade: 6
    },
    {
      IngredienteNome: 'g',
      IngredienteQuantidade: 7
    },
    {
      IngredienteNome: 'h',
      IngredienteQuantidade: 8
    },
    {
      IngredienteNome: 'i',
      IngredienteQuantidade: 9
    },
    {
      IngredienteNome: 'j',
      IngredienteQuantidade: 10
    }
  ];

  return (
    <Page title="Dashboard: Blog | Minimal-UI">
      <Container>
        <Stack direction="row" alignItems="center" justifyContent="space-between" mb={5}>
          <Typography variant="h4" gutterBottom>
            Estoque
          </Typography>
          <Button
            variant="contained"
            component={RouterLink}
            to="#"
            startIcon={<Icon icon={plusFill} />}
          >
            Adicionar ingrediente
          </Button>
        </Stack>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Ingrediente</TableCell>
                <TableCell>Quantidade&nbsp;(g)</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {rows.map((row) => (
                <TableRow key={row.name} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                  <TableCell component="th" scope="row">
                    {row.IngredienteNome}
                  </TableCell>
                  <TableCell>{row.IngredienteQuantidade}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Container>
    </Page>
  );
}
